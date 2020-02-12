using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanCollision : MonoBehaviour
{
    Collider globalOther;
    void Start()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player standing on fan");
            other.transform.parent.parent = this.transform.parent;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        globalOther = other;
        Invoke("DetachFromFan", 0.3f);
    }

    private void DetachFromFan()
    {
        if(globalOther.gameObject.tag == "Player")
        {
            globalOther.transform.parent.parent = null;
        }
    }
    

}
