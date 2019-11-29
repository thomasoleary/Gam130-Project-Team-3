using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycasting : MonoBehaviour
{

    public float range;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            HandleRaycast();
        }

    }

    private void HandleRaycast()
    {
        RaycastHit hit;


        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            print(hit);
        }
    }

}