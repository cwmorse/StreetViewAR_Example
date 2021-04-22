using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    public bool KeepVerticalPosition = true;

    public void Move(Vector3 newPosition)
    {
        if (KeepVerticalPosition)
        {
            transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
        }
        else
        {
            transform.position = newPosition;
        }
    }
}
