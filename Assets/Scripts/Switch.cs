using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    [SerializeField]
    private GameObject metalDetectors;

    [SerializeField]
    private GameObject movingWall;

    private RaycastHit hit;

    private Camera playerCamera;

    private Animator switchAnimation;

    private bool IsSwitchActivated = false;
    
    // MoveWall() related variables
    private Vector3 startPos;
    private Vector3 endPos;

    [SerializeField]
    private float distance = 5f;

    private float lerpTime = 5;
    private float currentLerpTime = 0;

    private void Start()
    {
        playerCamera = GameObject.Find("CharacterCamera").GetComponent<Camera>();
        switchAnimation = GetComponentInChildren<Animator>();

        startPos = movingWall.transform.position;
        endPos = movingWall.transform.position + Vector3.up * distance;
    }

    private void FixedUpdate()
    {
        Vector3 fwd = playerCamera.transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(playerCamera.transform.position, fwd * 2, Color.green);

        if(Physics.Raycast (playerCamera.transform.position, fwd, out hit))
        {
            if(hit.distance <= 7.0f)
            {
                if(hit.collider.gameObject.tag == "Switch" && Input.GetKeyDown("e"))
                {
                    // Debug.Log("Switch Activated");
                    switchAnimation.SetBool("ActivateSwitch", true);

                    metalDetectors.GetComponent<AudioSource>().enabled = false;
                    IsSwitchActivated = true;
                }
            }
        }

        if (IsSwitchActivated) { MoveWall(); }
    }


    
    void MoveWall()
    {
        currentLerpTime += Time.deltaTime;
        if(currentLerpTime >= lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        float Perc = currentLerpTime / lerpTime;
        movingWall.transform.position = Vector3.Lerp(startPos, endPos, Perc);
    }
}