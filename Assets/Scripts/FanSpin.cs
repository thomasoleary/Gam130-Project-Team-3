using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpin : MonoBehaviour
{

    [SerializeField]
    int spinSpeed = 20;

    private GameObject target = null;
    private Vector3 offset;

    void Start()
    {
        target = null;
    }

    void OnTriggerStay(Collider col)
    {
        target = col.gameObject;
        offset = target.transform.position - transform.position;
    }

    void OnTriggerExit(Collider col)
    {
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spinSpeed, 0 * Time.deltaTime);
    }

    void LateUpdate()
    {
        if (target != null)
        {
            target.transform.position = transform.position + offset;
        }
    }
}
