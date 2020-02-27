using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetectors : MonoBehaviour
{   
    [SerializeField]
    AudioClip detectorClip;

    private AudioSource detectorSource;
    bool PlayerEntered = false;

    private void Start()
    {
        detectorSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerAudio")
        {
            Debug.Log("Player has entered Metal Detectors");
            PlayerEntered = true;
            detectorSource.PlayOneShot(detectorClip);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "PlayerAudio")
        {
            Debug.Log("Player has left Metal Detectors");
            PlayerEntered = false;
            detectorSource.Stop();
        }
    }


}
