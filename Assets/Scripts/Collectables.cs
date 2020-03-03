using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Collectables : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreText;
    
    public int Score;
    
    void OnTriggerEnter(Collider other) {
        Score += 1;
        scoreText.GetComponent<Text>().text = "Score: " + Score;
        Destroy(gameObject);
    }

}
