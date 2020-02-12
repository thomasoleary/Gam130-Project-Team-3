using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    private bool collisionEnter = false;

    void Start()
    {
        collisionEnter = false;
    }

    // Update is called once per frame
    void Update()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (collisionEnter == true)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            collisionEnter = true;
        }
    }
}
