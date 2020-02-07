using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    bool InsideViewrange = false;
    bool IsBeingDetected = false;
    public GameObject playerObject;
    public float cameraViewRange;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InsideViewrange)
        {
            HandleRaycast();
            Debug.Log("In view range");
        }
        else
        {
            Debug.Log("Not In view range");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

        if(player != null)
        {
            InsideViewrange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

        if (player != null)
        {
            InsideViewrange = false;
        }
    }




    private void HandleRaycast()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player").gameObject;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, (playerObject.transform.position - transform.position), out hit, cameraViewRange))
        {
            PlayerMovement player = hit.transform.gameObject.GetComponent<PlayerMovement>();

            if (playerObject != null)
            {
                Debug.DrawRay(transform.position, (playerObject.transform.position - transform.position), Color.red);
                IsBeingDetected = true;
                this.gameObject.GetComponent<Animator>().SetBool("SeePlayer", true);
            }
            else
            {
                this.gameObject.GetComponent<Animator>().SetBool("SeePlayer", false);
                IsBeingDetected = false;
            }

        }
    }


}
