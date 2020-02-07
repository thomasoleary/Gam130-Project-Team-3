using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    bool InsideViewrange = false;
    bool IsBeingDetected = false;

    public GameObject playerObject;
    public float cameraViewRange;

    public GameObject light1, light2;

    void Update()
    {
        if(InsideViewrange)
        {
            HandleRaycast();
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
                StartCoroutine(CheckDetection());
            }
            else
            {
                IsBeingDetected = false;
            }

        }
    }

    void DetectedPlayer()
    {
        if (InsideViewrange)
        {
            Debug.Log("Game Over");
            // can add the ending bit here
        }
        else
        {
            this.gameObject.GetComponent<Animator>().SetBool("SeePlayer", false);
            light1.SetActive(true);
            light2.SetActive(false);
            return;
        }
  
    }

    IEnumerator CheckDetection()
    {
        light1.SetActive(false);
        light2.SetActive(true);
        yield return new WaitForSeconds(3);
        DetectedPlayer();
    }

}
