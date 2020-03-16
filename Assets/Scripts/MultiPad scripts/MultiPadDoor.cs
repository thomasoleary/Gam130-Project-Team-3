﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPadDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ArrayOfPads = new GameObject[3];
    private int count;

    private Vector3 startingPos;
    private Vector3 endingPos;

    [SerializeField]
    private float distance = 4f;

    private float lerpTime = 5;
    private float currentLerpTime = 0;

    private float Perc;

    void Start()
    {
        startingPos = transform.position;
        endingPos = transform.position + Vector3.up * distance;


        ArrayOfPads = GameObject.FindGameObjectsWithTag("PressurePad");
    }

    // Update is called once per frame
    void Update()
    {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime >= lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        /*for (int i = 0; i < ArrayOfPads.Length; i++)
        {
            if (ArrayOfPads[i].GetComponent<PressurePad>().padActivated == false)
            {
                count++;
            }
        }
        Debug.Log(count);
        */

        if (AllPadsActivated())
        {
            Debug.Log("All pads");
        }
    }

    private bool AllPadsActivated()
    {
        for(int i = 0; i < ArrayOfPads.Length; i++)
        {
            if(ArrayOfPads[i].GetComponent<PressurePad>().padActivated == false)
            {
                return false;
            }
        }

        return true;
    }
    
}
