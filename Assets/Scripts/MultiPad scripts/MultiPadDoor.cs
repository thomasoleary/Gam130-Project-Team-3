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


    //private bools that will be set to booleans in PressurePad.cs
    private bool pad1;
    private bool pad2;
    private bool pad3;

    Vector3 startingPos; // Grab original position of the door/wall
    Vector3 endingPos; // Same position except Y position is altered
    private float duration = 5f; 

    void Start()
    {
        // sets startingPos vector to position of Wall
        startingPos.Set(transform.position.x, transform.position.y, transform.position.z);
        //Debug.Log(startingPos);
        
        // adding value onto startingPos
        endingPos.Set(startingPos[0], startingPos[1] + 6, startingPos[2]);
        //Debug.Log(endingPos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // setting bools value of padActivated in PressurePad
        pad1 = pressurePadOne.GetComponent<PressurePad>().padActivated;
        pad2 = pressurePadTwo.GetComponent<PressurePad>().padActivated;
        pad3 = pressurePadThree.GetComponent<PressurePad>().padActivated;

        OpenDoor();
        
    }
    private void OpenDoor()
    {
        // if all pads are activated, move between values 
        if(pad1 && pad2 && pad3)
        {
            transform.position = Vector3.Lerp(startingPos, endingPos, Time.time - duration);
        }
        else
        {
            // go back to original position if no
            transform.position = startingPos;
        }
    }
    
}
