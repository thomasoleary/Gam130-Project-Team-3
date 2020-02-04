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
        Debug.Log("Opening door");
    }
}
