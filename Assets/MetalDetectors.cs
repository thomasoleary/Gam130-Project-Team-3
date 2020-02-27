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

    //private float currentVolume;
    //private float endingVolume = 0f;
    //private float duration = 5f;

    private void Start()
    {
        detectorSource = GetComponent<AudioSource>();
        //currentVolume = detectorSource.volume;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerAudio" && DetectorsActivated)
        {
            Debug.Log("Player has entered Metal Detectors");
            PlayerEntered = true;
            detectorSource.volume = 1f;
            detectorSource.PlayOneShot(detectorClip);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "PlayerAudio" && DetectorsActivated)
        {
            Debug.Log("Player has left Metal Detectors");
            PlayerEntered = false;
            //detectorSource.volume = Mathf.Lerp(currentVolume, endingVolume, duration);
            detectorSource.Stop();
        }
    }


}
