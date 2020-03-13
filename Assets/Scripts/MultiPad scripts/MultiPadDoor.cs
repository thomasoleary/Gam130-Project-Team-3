using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPadDoor : MonoBehaviour
{

    //Refrence Pressure Pads in scenes
    [SerializeField]
    GameObject pressurePadOne;
    [SerializeField]
    GameObject pressurePadTwo;
    [SerializeField]
    GameObject pressurePadThree;

    private float distance = 5f;


    //private bools that will be set to booleans in PressurePad.cs
    private bool pad1;
    private bool pad2;
    private bool pad3;

    private float currentLerpTime;
    private float lerpTime = 5f;
    private float Perc;

    private Vector3 startingPos;
    private Vector3 endingPos;
    private Vector3 currentPos;

    void Start()
    {
        startingPos = transform.position;
        endingPos = transform.position + Vector3.up * distance;
    }

    // Update is called once per frame
    void Update()
    {
        

        // setting bools value of padActivated in PressurePad
        pad1 = pressurePadOne.GetComponent<PressurePad>().padActivated;
        pad2 = pressurePadTwo.GetComponent<PressurePad>().padActivated;
        pad3 = pressurePadThree.GetComponent<PressurePad>().padActivated;
        
        currentLerpTime += Time.deltaTime;
        if(currentLerpTime >= lerpTime)
        {
            currentLerpTime = lerpTime;
        }
        Perc = currentLerpTime / lerpTime;

        OpenDoor();
        
    }
    private void OpenDoor()
    { 

        // if all pads are activated, move between values 
        if(pad1 && pad2)
        {
            // Debug.Log("Door open");
            transform.position = Vector3.Lerp(startingPos, endingPos, Perc);
        }
        else
        {
            //Perc = currentLerpTime / lerpTime;
            //currentPos = transform.position;
            //transform.position = Vector3.Lerp(currentPos, startingPos, Perc);
        }
    }
    
}
