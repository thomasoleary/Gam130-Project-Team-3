using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBasedFOV : MonoBehaviour
{


    private BoxCollider triggerPoint;
    private bool fovIncrease = false;

    float fieldOfView;
    // Start is called before the first frame update
    void Start()
    {
        fieldOfView = 60.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if ((fovIncrease == true) && (fieldOfView < 165.0f))
        {
            Camera.current.fieldOfView = (fieldOfView += (Time.deltaTime * 20));
        }
        else
            Camera.current.fieldOfView = fieldOfView;
    }

    void OnTriggerEnter(Collider other)
    {
        fovIncrease = true;
    }
}