using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleLocationIndicatorWithCamera : MonoBehaviour
{
    public Camera MapCamera;
       

    // Update is called once per frame
    void Update()
    {
        float s = MapCamera.orthographicSize / 10; //TESTING
        gameObject.transform.localScale = new Vector3(s, s, s);
    }
}
