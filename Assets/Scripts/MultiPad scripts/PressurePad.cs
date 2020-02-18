using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    [SerializeField]
    Light colourIndicator;

    private Color redColour = Color.red;
    private Color greenColour = Color.green;
    private float duration = 1f;

    private void OnTriggerEnter(Collider other)
    {
        colourIndicator.color = Color.Lerp(redColour, greenColour, duration);
        Debug.Log("Player collided with trigger");

    }

    private void OnTriggerExit(Collider other)
    {
        colourIndicator.color = Color.Lerp(greenColour, redColour, duration);
        Debug.Log("Player has left the trigger");

    }
}
