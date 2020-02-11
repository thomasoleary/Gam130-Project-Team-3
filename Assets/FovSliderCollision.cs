using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovSliderCollision : MonoBehaviour
{
    float fieldOfView;
    bool collisionEnter = false;

    [SerializeField]
    private Camera cam;

    static float t = 0f;
    public float fovSpeedModifier = 1f;
    public float maxFov = 145f;
    public void Start()
    {
        fieldOfView = 70.0f;

    }

    void FixedUpdate()
    {
        

        if ((fieldOfView < maxFov) && (collisionEnter == true))
        {
            //cam.fieldOfView += Time.deltaTime * 20;
            t += fovSpeedModifier * Time.deltaTime / 2f;
            cam.fieldOfView = Mathf.Lerp(fieldOfView, maxFov, t);

        }
        else if (collisionEnter == true)
        {
            cam.fieldOfView = maxFov;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            collisionEnter = true;
        }
    }
}
