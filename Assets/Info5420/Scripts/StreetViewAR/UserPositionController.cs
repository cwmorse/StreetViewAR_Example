using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Info5420.StreetViewAR
{
    public class UserPositionController : MonoBehaviour
    {
        private float rotationCoarse = 0;
        private float rotationFine = 0;

        private float verticalCoarse = 0;
        private float verticalFine = 0;

        private Vector3 initialPosition;
               
      


        private void Start()
        {           

            initialPosition = transform.position;
        }

        public void setCoarseRotation(float angle)
        {
            rotationCoarse = angle;
            SetRotation();
        }

        public void setFineRotation(float angle)
        {
            rotationFine = angle;
            SetRotation();
        }


        public void moveVerticalFine(float value)
        {
            verticalFine = value;
            SetVertical();
        }

        public void moveVertical(float value)
        {
            verticalCoarse = value;
            SetVertical();
        }

        private void SetVertical()
        {
            //camera also moves from map, so can't just use initial position at start. Need to get x and z from current position, but y from initial position
            Vector3 newPosition = transform.position;
            newPosition.y = initialPosition.y;
            transform.position = new Vector3(0, verticalCoarse + verticalFine, 0) + newPosition;
        }

        private void SetRotation()
        {
            transform.rotation = Quaternion.Euler(0, rotationCoarse + rotationFine, 0);
        }


    }
}
