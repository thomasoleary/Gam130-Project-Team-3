﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    public bool InsideViewrange = false;
    public bool IsBeingDetected = false;

    public GameObject playerObject;

    public GameObject light1, light2;
    public Light camLight;
    public Color origColor;
    public Color detectColor;


    public enum CamState
    {
        lookingLeft,
        LookingRight,
        Detected
    }
    public CamState cameraState;
    [SerializeField]
    private GameObject camLeftPos;
    [SerializeField]
    private GameObject camRightPos;
    [SerializeField]
    private float camRotationSpeed;
    [SerializeField]
    private float camTurnDelay;



    Animator anim;


    
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player").gameObject;
        anim = GetComponent<Animator>();


    }

    void Update()
    {
        CameraChecker();
        anim.speed = camRotationSpeed;


        if (InsideViewrange)
        {
            Debug.Log("inside view range");
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
            IsBeingDetected = false;
        }
    }




    private void HandleRaycast()
    {
     
        RaycastHit hit;

        if (Physics.Raycast(transform.position, (playerObject.transform.position - transform.position), out hit))
        {

            if (hit.collider.tag == "Player")
            {
                
                Debug.DrawRay(transform.position, (playerObject.transform.position - transform.position), Color.red);
                IsBeingDetected = true;
                this.gameObject.GetComponent<Animator>().SetBool("SeePlayer", true);
                StartCoroutine(CheckDetection());
            }
            else
            {
                Debug.Log("not being detected");
                IsBeingDetected = false;
                StopCoroutine(CheckDetection());
            }

        }
    }

    void DetectedPlayer()
    {
        if (IsBeingDetected)
        {
            Debug.Log("Game Over");
            // can add the ending bit here
        }
        else
        {
            //this.gameObject.GetComponent<Animator>().SetBool("SeePlayer", false);
            this.gameObject.GetComponent<Animator>().enabled = true;
            camLight.color = origColor;
            light1.SetActive(true);
            light2.SetActive(false);
            return;
        }
  
    }

    public void CameraChecker()
    {
        if(camLeftPos != null)
        {
            if (cameraState == CamState.lookingLeft)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, camLeftPos.transform.rotation, camRotationSpeed * Time.deltaTime);
                StartCoroutine(CamRotateRight());
            }
            else if (cameraState == CamState.LookingRight)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, camRightPos.transform.rotation, camRotationSpeed * Time.deltaTime);
                StartCoroutine(CamRotateLeft());
            }
        }
    
    }

    IEnumerator CamRotateLeft()
    {
        yield return new WaitForSeconds(camTurnDelay);
        cameraState = CamState.lookingLeft;
    }

    IEnumerator CamRotateRight()
    {
        yield return new WaitForSeconds(camTurnDelay);
        cameraState = CamState.LookingRight;
    }


    IEnumerator CheckDetection()
    {
        this.gameObject.GetComponent<Animator>().enabled = false;
        light1.SetActive(false);
        light2.SetActive(true);
        camLight.color = detectColor;
        yield return new WaitForSeconds(3);
        DetectedPlayer();
    }

}
