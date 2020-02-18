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

    Vector3 startingPos;
    Vector3 endingPos;
    private float duration = 5f;

    void Start()
    {
        startingPos.Set(transform.position.x, transform.position.y, transform.position.z);
        Debug.Log(startingPos);
        endingPos.Set(startingPos[0], startingPos[1] + 6, startingPos[2]);
        Debug.Log(endingPos);
    }

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
            transform.position = Vector3.Lerp(startingPos, endingPos, Time.time - duration);
        }
        else
        {
            transform.position = startingPos;
        }
    }
    
}
