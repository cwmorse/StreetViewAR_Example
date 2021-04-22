using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLocationIndicatorWithARCamera : MonoBehaviour
{
    public Camera ARCamera;


    // Update is called once per frame
    void Update()
    {
        Vector3 rotationEuler = ARCamera.transform.localEulerAngles;
        rotationEuler.x = gameObject.transform.localEulerAngles.x;
        rotationEuler.z = 0;
        gameObject.transform.localRotation = Quaternion.Euler(rotationEuler);
    }
}
