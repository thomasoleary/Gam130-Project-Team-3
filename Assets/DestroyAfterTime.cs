using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float Timer;

    void Start()
    {
        Invoke("DestroyObject", Timer);
    }


    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
