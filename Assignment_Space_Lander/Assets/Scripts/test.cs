using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    /*public static test instance;

    public TMP_Text highScore;

    public TMP_Text timeScore;

    public bool timerActive = true;

    public float timeTaken;

    public float sceneBestTime = 60f;
    

    private void Start()
    {
        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("F2");
        
        sceneBestTime = PlayerPrefs.GetFloat("CurrentBestTime", sceneBestTime);
    }

    private void Update()
    {
        if (timerActive)
        {
            timeTaken += Time.deltaTime;

            timeScore.text = timeTaken.ToString("F2");
        }
        
    }

    public void StopTimer()
    {
        timerActive = false;

        if (timeTaken < sceneBestTime)
        {
            highScore.text = timeTaken.ToString("F2");

            PlayerPrefs.SetFloat("CurrentBestTime", timeTaken);

            PlayerPrefs.SetFloat("HighScore", timeTaken);
        }
    }*/

    public static test instance;

    public TMP_Text highScore;
    public TMP_Text timeScore;
    public bool timerActive = true;
    public float timeTaken;

    // Unique identifier for the current scene
    public string sceneIdentifier;

    private void Start()
    {
        // Load the best time for the current scene
        sceneIdentifier = SceneManager.GetActiveScene().name;
        highScore.text = PlayerPrefs.GetFloat(sceneIdentifier + "HighScore", 0).ToString("F2");
    }

    private void Update()
    {
        if (timerActive)
        {
            timeTaken += Time.deltaTime;
            timeScore.text = timeTaken.ToString("F2");
        }
    }

    public void StopTimer()
    {
        timerActive = false;

        // Load the previous best time for the current scene
        float previousBestTime = PlayerPrefs.GetFloat(sceneIdentifier + "HighScore", float.MaxValue);

        if (timeTaken < previousBestTime)
        {
            // Update and save the best time for the current scene
            highScore.text = timeTaken.ToString("F2");
            PlayerPrefs.SetFloat(sceneIdentifier + "HighScore", timeTaken);
        }
    }
}
