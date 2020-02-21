using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpin : MonoBehaviour
{

    [SerializeField]
    float spinSpeed = 20f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spinSpeed, 0 * Time.deltaTime);
    }
}
