using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    [SerializeField]
    GameObject movingObject;

    [SerializeField]
    Light colourIndicator;

    Animator objectAnimation;

    private Color redColour = Color.red;
    private Color greenColour = Color.green;
    float duration = 1f;

    private void Start()
    {
        objectAnimation = movingObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player collided with trigger");

        objectAnimation.SetBool("OpenDoor", true);
        colourIndicator.color = Color.Lerp(redColour, greenColour, duration);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player has left the trigger");

        objectAnimation.SetBool("OpenDoor", false);
        colourIndicator.color = Color.Lerp(greenColour, redColour, duration);
    }
}
