using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    
    public GameObject pickedUpObject;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            if(hit.collider.gameObject.tag == "pickObject")
            {
                pickedUpObject = hit.collider.gameObject;
                hit.collider.gameObject.transform.parent = transform;
                hit.collider.gameObject.transform.position = (transform.position + transform.forward);
                hit.rigidbody.useGravity = false;
            }
        }
        else
        {
            //pickedUpObject.transform.parent = null;
            pickedUpObject = null;
        }
    }
}
