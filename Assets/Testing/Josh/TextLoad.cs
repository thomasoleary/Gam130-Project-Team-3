using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLoad : MonoBehaviour
{
    public GameObject textObject;
   
    
    // Start is called before the first frame update
    void Start()
    {
        textObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider player) {
        if (player.gameObject.tag == "Player") {
            textObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }

        IEnumerator WaitForSec() {
            yield return new WaitForSeconds(5);
            Destroy(textObject);
            Destroy(gameObject);
        
        }
    }
}
