using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool priceReached;

    public int maxPriceAmount;
    public int currentPriceAmount;

    void ReachedAmount()
    {
        priceReached = true;
        Debug.Log("open door or whatever");
    }

    public void AddPrice(int amount)
    {
        currentPriceAmount += amount;

        if(currentPriceAmount >= maxPriceAmount)
        {
            ReachedAmount();
        }
     
    }
}
