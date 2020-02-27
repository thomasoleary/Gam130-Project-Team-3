using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
            // Debug.Log("Player has entered Metal Detectors");
            PlayerEntered = true;
            detectorSource.volume = 1f;
            detectorSource.PlayOneShot(detectorClip);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "PlayerAudio" && DetectorsActivated)
        {
            // Debug.Log("Player has left Metal Detectors");
            PlayerEntered = false;
            detectorSource.Stop();
        }
    }


}
