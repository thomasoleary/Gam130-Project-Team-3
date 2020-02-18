using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPadDoor : MonoBehaviour
{
    [SerializeField]
    GameObject pressurePadOne;
    [SerializeField]
    GameObject pressurePadTwo;
    [SerializeField]
    GameObject pressurePadThree;

    private bool pad1;
    private bool pad2;
    private bool pad3;

    // Update is called once per frame
    void FixedUpdate()
    {
        pad1 = pressurePadOne.GetComponent<PressurePad>().padActivated;
        pad2 = pressurePadTwo.GetComponent<PressurePad>().padActivated;
        pad3 = pressurePadThree.GetComponent<PressurePad>().padActivated;

        OpenDoor();
        
    }
    private void OpenDoor()
    {
        if(pad1 && pad2 && pad3)
            {
                Debug.Log("All Pads activated");
            }
    }
    
}
