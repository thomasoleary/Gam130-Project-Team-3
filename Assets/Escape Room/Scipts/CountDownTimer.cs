using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CountDownTimer : MonoBehaviour
{
    public float timeLeft = 900.0f;
    public Text text;
    bool clock;
    private float mins;
    private float secs;

    void Update()
    {
        if (timeLeft > 0 && clock == false)
        {
            clock = true;
            StartCoroutine(Wait());
        }

        if(timeLeft <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator Wait()
    {
        timeLeft -= 1;
        UpdateTimer();
        yield return new WaitForSeconds(1);
        clock = false;
    }

    void UpdateTimer()
    {
        int min = Mathf.FloorToInt(timeLeft / 60);
        int sec = Mathf.FloorToInt(timeLeft % 60);
        text.GetComponent<UnityEngine.UI.Text>().text = min.ToString("00") + ":" + sec.ToString("00");
    }
}

