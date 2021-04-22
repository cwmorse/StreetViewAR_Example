using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Info5420.Utilities
{

    /// <summary>
    /// Attach to a button to simply toggle something else on or off
    /// </summary>
    public class ToggleGameObject : MonoBehaviour
    {       
        public void Toggle()
        {
            gameObject.SetActive(!gameObject.activeSelf);     
        }
    }
}
