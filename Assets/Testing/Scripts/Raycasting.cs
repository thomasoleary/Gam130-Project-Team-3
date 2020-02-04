using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    RaycastHit hit;
    GameObject pickedUpObject;

    public GameObject dropPoint;
    private bool hasItem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(hasItem)
            {
                DropPickup();
            }
            else
            {
                Pickup();
            }
     
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
                hasItem = true;
            }
        }
        else
        {
            pickedUpObject = null;
        }
    }

    void DropPickup()
    {
        pickedUpObject.transform.parent = null;
        pickedUpObject.transform.position = dropPoint.transform.position;
        pickedUpObject.GetComponent<Rigidbody>().useGravity = true;
        pickedUpObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        hasItem = false;
    }
}
