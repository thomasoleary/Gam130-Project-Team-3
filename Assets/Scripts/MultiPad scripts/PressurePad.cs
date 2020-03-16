using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    [SerializeField]
    Light colourIndicator;

    private Color redColour = Color.red;
    private Color greenColour = Color.green;
    public bool padActivated;

    private void OnTriggerStay(Collider other)
    {
        padActivated = true;
        colourIndicator.color = Color.Lerp(redColour, greenColour, 1f);
    }

    private void OnTriggerExit(Collider other)
    {
        padActivated = false;
        colourIndicator.color = Color.Lerp(greenColour, redColour, 1f);
    }
}
