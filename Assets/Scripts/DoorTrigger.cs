using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
   
    public GameObject door;

    bool isOpen = false;

    void onTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {

            Debug.Log("Player is standing on plate");
            //if (!isOpen)
            //    {
            //        isOpen = true;
            //        door.transform.position += new Vector3(0, 4, 0);
            //    }
        }
        
    }
}
