using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemPrice;
    bool canGetPicked = true;
    GameManager gameManager;

    public bool isCollectable;


    void Start()
    {
        if(this.gameObject.CompareTag("Collectable")) { isCollectable = true; }
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Trolley") && canGetPicked)
        {
            canGetPicked = false;
            gameManager.AddPrice(itemPrice);
        }
        else if(other.gameObject.CompareTag("Player") && isCollectable)
        {
            if(gameManager != null)
            {
                if(this.gameObject.name == "Red")
                {
                    gameManager.WriteInstructions();
                    Destroy(this.gameObject);
                }
                else if(this.gameObject.name == "Blue")
                {
                    gameManager.StoryLineInfo();
                    Destroy(this.gameObject);
                }
    
            }
        }
    }


}
