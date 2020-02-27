﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    private GameObject metalDetectors;

    public RaycastHit hit;
    private bool leverActivated = false;

    public Camera playerCamera;

    private void Start()
    {
        playerCamera = GameObject.Find("CharacterCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 fwd = playerCamera.transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(playerCamera.transform.position, fwd * 2, Color.green);

        if(Physics.Raycast (playerCamera.transform.position, fwd, out hit))
        {
            if(hit.distance <= 7.0f)
            {
                if(hit.collider.gameObject.tag == "Switch" && Input.GetKeyDown("e"))
                {
                    Debug.Log("Switch Activated");
                }
            }
        }
    }
}
