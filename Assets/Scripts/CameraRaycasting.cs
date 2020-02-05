using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycasting : MonoBehaviour
{
  
    public float range;
    Interactable interactableScript;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {        
            HandleRaycast();
        }

    }

    private void HandleRaycast()
    {
        RaycastHit hit;
       
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            interactableScript = hit.transform.gameObject.GetComponent<Interactable>();

            if (interactableScript != null)
            {
                if(hit.transform.gameObject.CompareTag("Door"))
                {
                    interactableScript.PlayerUnlock();
                }
                else if (hit.transform.gameObject.CompareTag("ExitDoor"))
                {
                    interactableScript.OpenExit();
                }
            }
       
        }
    }

}