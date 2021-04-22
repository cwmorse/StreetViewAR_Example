using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Use this component to set the material to be an occlusion material
/// </summary>
public class SetOccludingObjects : MonoBehaviour
{
    /// <summary>
    /// Set this to the OccludingMaterial
    /// </summary>
    /// TODO - add OccludingMaterial to resources so I can always use it without having to reference it
    public Material OccludingMaterial;

    /// <summary>
    /// Apply this behavior to all the of the descendants of this object
    /// </summary>
    public bool Recursive = false;

    /// <summary>
    /// If true, all the objects should have the 'occludingmaterial' set
    /// </summary>
    public bool IsOccluding = false;

      
    /// <summary>
    /// If set, look for the named game object to use instead of 'this'
    /// </summary
    [Tooltip("Uses name rather than GameObject reference in order to allow for runitme model loading if needed ")]
    public List<GameObject> OccludingObjects;

    private Dictionary<MeshRenderer, Material> materialDictionary;

    private void Awake()
    {
        materialDictionary = new Dictionary<MeshRenderer, Material>();

        if (OccludingObjects.Count > 0)
        {
            foreach (var go in OccludingObjects)
            {
                PopulateMaterialDictionary(go);
            }
        }
        else
        {
            PopulateMaterialDictionary(gameObject);
        }

        if (IsOccluding)
        {
            SetOcclusion(IsOccluding);           
        }
    }


    private void PopulateMaterialDictionary(GameObject go)
    {
        var mr = go.GetComponent<MeshRenderer>();
        if(mr!=null)
        {
            materialDictionary.Add(mr, mr.material);
        }

        if(Recursive)
        {
            for(int i=0;i<go.transform.childCount;i++)
            {
                PopulateMaterialDictionary(go.transform.GetChild(i).gameObject);
            }
        }
    }

    public void SetOcclusion(bool value)
    {        
        IsOccluding = value;
        foreach (var mr in materialDictionary.Keys)
        {
            mr.material = IsOccluding ? OccludingMaterial : materialDictionary[mr];
        }
    }

    public void ToggleOcclusion()
    {
        SetOcclusion(!IsOccluding);
    }
}
