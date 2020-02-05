using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public bool isUnlocked = false;
    public Light doorLight;
    Animator leverAnim;

    public LevelManager managerScript;

    void Start()
    {
        leverAnim = gameObject.GetComponentInChildren<Animator>();
        managerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelManager>();
        doorLight.color = Color.red;
    }

    public void PlayerUnlock()
    {
        if(!isUnlocked)
        {
            leverAnim.SetTrigger("Open");
            isUnlocked = true;
            managerScript.HasAllDoorsBeenUnlocked();
            doorLight.color = Color.green;
        }
     
    }

    public void OpenExit()
    {
        if(managerScript.canExit)
        {
            leverAnim.SetTrigger("Open");
            // can add more stuff later for the next level
        }
        else
        {
            return;
        }
    }



}
