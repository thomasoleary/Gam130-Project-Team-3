using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject shootPoint;

    void Update()
    {
      

    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10);
    }


}
