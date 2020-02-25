using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetectors : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player has entered Metal Detectors");
        }
    }


}
