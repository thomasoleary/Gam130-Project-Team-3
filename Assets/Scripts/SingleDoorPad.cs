using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDoorPad : MonoBehaviour
{
    [SerializeField]
    GameObject movingObject;

    [SerializeField]
    Light colourIndicator;

    private Vector3 startingPos;
    private Vector3 endingPos;
    private Vector3 currentPos;

    [SerializeField]
    private float distance = 4f;

    private float lerpTime = 5f;
    private float currentLerpTime = 0f;
    private float Perc;


    private Color redColour = Color.red;
    private Color greenColour = Color.green;
    float duration = 1f;

    private void Start()
    {
        startingPos = movingObject.transform.position;
        endingPos = startingPos + Vector3.up * distance;
    }

    private void Update()
    {
        currentLerpTime += Time.deltaTime;
        if(currentLerpTime >= lerpTime)
        {
            currentLerpTime = lerpTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Perc = currentLerpTime / lerpTime;
        colourIndicator.color = Color.Lerp(redColour, greenColour, duration);
        //movingObject.transform.position = Vector3.Lerp(startingPos, endingPos, Perc);

        LeanTween.moveLocalY(movingObject, endingPos[1], Perc);
        
    }

    private void OnTriggerExit(Collider other)
    {
        Perc = currentLerpTime / lerpTime;
        currentPos = transform.position;
        colourIndicator.color = Color.Lerp(greenColour, redColour, duration);

        LeanTween.moveLocalY(movingObject, startingPos[1], Perc);

        //movingObject.transform.position = Vector3.Lerp(currentPos, startingPos, Perc);

    }
}
