using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanCollision : MonoBehaviour
{
    void Start()
    {
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //Debug.Log("Player standing on fan");
            col.transform.parent = this.transform;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
    }

}
