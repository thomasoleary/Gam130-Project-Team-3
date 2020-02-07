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

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spinSpeed, 0 * Time.deltaTime);
    }
}
