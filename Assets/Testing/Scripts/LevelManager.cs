using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public Light mainDoorlight1;
    public Light mainDoorlight2;
    public bool door1Unlocked = false;
    public bool door2Unlocked = false;
    public GameObject[] doors;
    public int amountOfOpenedDoors = 0;

    void UnlockExit()
    {
        mainDoorlight1.color = Color.green;
        mainDoorlight2.color = Color.green;
    }

    public void HasAllDoorsBeenUnlocked()
    {
       
        for (int i = 0; i < doors.Length; i++)
        {         
            if (doors[i].transform.gameObject.GetComponent<Interactable>().isUnlocked)
            {
                amountOfOpenedDoors++;
                print(amountOfOpenedDoors);

                if(amountOfOpenedDoors == doors.Length)
                {
                    UnlockExit();
                    break;
                }
            
            }
            else
            {
                return;
            }
           
        }

    }

}
