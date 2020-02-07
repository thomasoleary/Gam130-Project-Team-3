using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanCollision : MonoBehaviour
{
    private GameObject target = null;
    private Vector3 offset;
    void Start()
    {
        target = null;
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Player standing on fan");
        }
        target = col.gameObject;
        offset = target.transform.position - transform.position;
    }

    public void OnTriggerExit(Collider col)
    {
        target = null;
    }

    public void LateUpdate()
    {
        if (target != null)
        {
            target.transform.position = transform.position + offset;
        }
    }

}
