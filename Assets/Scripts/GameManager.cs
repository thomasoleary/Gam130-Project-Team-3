using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool priceReached;

    public int maxPriceAmount;
    public int currentPriceAmount;
    public GameObject light1, light2;
    public TextMeshProUGUI trolleyText;

    void ReachedAmount()
    {
        light1.SetActive(false);
        light2.SetActive(true);
        priceReached = true;
        Debug.Log("open door or whatever");
    }

    public void AddPrice(int amount)
    {
        currentPriceAmount += amount;
        trolleyText.text = " " + currentPriceAmount;

        if(currentPriceAmount >= maxPriceAmount)
        {
            ReachedAmount();
        }
     
    }

    public void WriteInstructions()
    {
        // fungus shit 
    }


    public void StoryLineInfo()
    {
        // fungus shit 
    }

}
