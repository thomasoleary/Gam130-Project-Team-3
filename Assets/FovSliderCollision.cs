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
    public void Start()
    {
        fieldOfView = 70.0f;

    }

    void FixedUpdate()
    {
        

        if ((fieldOfView < 125.0f) && (collisionEnter == true))
        {
            //cam.fieldOfView += Time.deltaTime * 20;
            t += 0.5f * Time.deltaTime / 2f;
            cam.fieldOfView = Mathf.Lerp(fieldOfView, 125f, t);

        }
        else if (collisionEnter == true)
        {
            cam.fieldOfView = 125.0f;
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
