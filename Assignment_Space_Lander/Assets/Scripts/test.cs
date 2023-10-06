using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class test : MonoBehaviour
{
    public TMP_Text highScore;

    public TMP_Text timeScore;

    public bool timerActive = true;

    public float timeTaken;

    public float sceneBestTime = 60f;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();

        sceneBestTime = PlayerPrefs.GetFloat("CurrentBestTime", sceneBestTime);
    }

    private void Update()
    {
        if (timerActive)
        {
            timeTaken += Time.deltaTime;

            timeScore.text = timeTaken.ToString();
        }
    }

    public void StopTimer()
    {
        timerActive = false;

        if (timeTaken < sceneBestTime)
        {
            highScore.text = timeTaken.ToString();

            PlayerPrefs.SetFloat("CurrentBestTime", timeTaken);

            PlayerPrefs.SetFloat("HighScore", timeTaken);
        }
    }
}
