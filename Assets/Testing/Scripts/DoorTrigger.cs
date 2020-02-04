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
            if (!isOpen)
                {
                    isOpen = true;
                    door.transform.position += new Vector3(0, 4, 0);
                }
        }
        
    }
}
