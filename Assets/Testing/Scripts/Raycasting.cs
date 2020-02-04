using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    RaycastHit hit;
    GameObject pickedUpObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        
        if(Physics.Raycast(transform.position, transform.forward, out hit, 2))
        {
            if(hit.collider.gameObject.tag == "pickObject")
            {
                pickedUpObject = hit.collider.gameObject;
                hit.collider.gameObject.transform.parent = transform;
                hit.collider.gameObject.transform.position = (transform.position + transform.forward);

                hit.rigidbody.useGravity = false;
                hit.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
        else
        {
            pickedUpObject = null;
        }
    }
}
