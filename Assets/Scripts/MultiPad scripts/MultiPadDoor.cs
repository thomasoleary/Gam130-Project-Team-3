using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPadDoor : MonoBehaviour
{
    private GameObject[] ArrayOfPads = new GameObject[3];

    private Vector3 startingPos;
    private Vector3 endingPos;
    private float currentPos;

    [SerializeField]
    private float distance = 4f;

    void Start()
    {
        startingPos = transform.position;
        endingPos = transform.position + Vector3.up * distance;

        ArrayOfPads = GameObject.FindGameObjectsWithTag("PressurePad");
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position.y;

        if (AllPadsActivated())
        {
            StopCoroutine("CloseDoor");
            StartCoroutine("OpenDoor");
        }
        else if (!AllPadsActivated())
        {
            if(currentPos != startingPos[1])
            {
                StopCoroutine("OpenDoor");
                StartCoroutine("CloseDoor");
            }
        }
    }

    private bool AllPadsActivated()
    {
        for(int i = 0; i < ArrayOfPads.Length; i++)
        {
            if(ArrayOfPads[i].GetComponent<PressurePad>().padActivated == false)
            {
                return false;
            }
        }

        return true;
    }


    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(0.5f);
        LeanTween.moveLocalY(gameObject, endingPos[1], 0.5f);
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(0.5f);
        LeanTween.moveLocalY(gameObject, startingPos[1], 0.5f);
    }
}
