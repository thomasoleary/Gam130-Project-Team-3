using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpin : MonoBehaviour
{

    [SerializeField]
    int spinSpeed = 20;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spinSpeed, 0 * Time.deltaTime);
    }
}
