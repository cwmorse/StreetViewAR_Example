using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOccludable : MonoBehaviour
{
    public int RenderQueue = 2002;
    public bool Recursive;

    /// <summary>
    /// Attach to individual gameobjects to make them and all children able to be occulded by ghost objects
    /// </summary>
    void Start()
    {


        MakeObjectOccluded(transform, Recursive);

    }

    private void MakeObjectOccluded(Transform t, bool recursive = false)
    {
        var renderers = t.GetComponents<Renderer>();
        foreach (var r in renderers)
        {
            r.sharedMaterial.renderQueue = RenderQueue;
        }
        if (recursive)
        {
            for (int i = 0; i < t.childCount; i++)
            {
                MakeObjectOccluded(t.GetChild(i), true);
            }
        }
    }
}
