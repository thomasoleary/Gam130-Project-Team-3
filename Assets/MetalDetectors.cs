using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MetalDetectors : MonoBehaviour
{   
    [SerializeField]
    AudioClip detectorClip;

    private AudioSource detectorSource;
    bool PlayerEntered = false;
    bool DetectorsActivated = true;


    private void Start()
    {
        detectorSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if(detectorSource.enabled == false)
        {
            DetectorsActivated = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerAudio" && DetectorsActivated)
        {
            PlayerEntered = true;

            if (PlayerEntered) 
            {
                detectorSource.volume = 0.2f;
                detectorSource.PlayOneShot(detectorClip);
                StartCoroutine("RestartScene");
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "PlayerAudio" && DetectorsActivated)
        {
            PlayerEntered = false;

            if (!PlayerEntered)
            {
                StopCoroutine("RestartScene");
                detectorSource.Stop();
                
            }
            
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(5);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

}
