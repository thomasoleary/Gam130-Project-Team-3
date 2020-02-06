using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemPrice;
    bool canGetPicked = true;
    GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Trolley") && canGetPicked)
        {
            canGetPicked = false;
            gameManager.AddPrice(itemPrice);
        }
    }


}
