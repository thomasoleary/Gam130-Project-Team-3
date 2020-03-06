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

    [SerializeField]
    private float startingPos;
    [SerializeField]
    private float endingPos;
    [SerializeField]
    private float duration;

    // Update is called once per frame
    void LateUpdate()
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
            //transform.position = Vector3.Lerp(startingPos, endingPos, Time.time - duration);
            LeanTween.moveLocalY(gameObject, endingPos, duration);
        }
        else
        {
            LeanTween.moveLocalY(gameObject, startingPos, duration);
        }
    }
    
}
