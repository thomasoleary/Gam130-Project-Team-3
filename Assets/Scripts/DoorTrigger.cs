using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]    
    GameObject door;

    bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player collided with trigger");
            if (!isOpen)
            {
                door.transform.position += new Vector3(0, 4, 0);
            }
        }
    }
}
