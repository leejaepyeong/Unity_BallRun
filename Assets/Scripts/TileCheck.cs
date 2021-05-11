using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCheck : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Pref")
        {
            GameManager.instance.isEmpty = true;
        }
    }
}
