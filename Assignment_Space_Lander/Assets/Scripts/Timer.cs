using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("Timer instace")]
    public static Timer instance;
    [Space]

    [Header("Text references")]
    public TMP_Text highScore;
    public TMP_Text timeScore;
    [Space]

    [Header("Time variables")]
    public bool timerActive = true;
    public float timeTaken;

    //identifier for the our current scenes
    public string scenesIdentifier;

    private void Start()
    {
        //We load our best time using PlayerPrefs.GetFloat
        scenesIdentifier = SceneManager.GetActiveScene().name;
        highScore.text = PlayerPrefs.GetFloat(scenesIdentifier + "HighScore", 0).ToString("F2");
    }

    private void Update()
    {
        //If timerActive then we start our time
        if (timerActive)
        {
            timeTaken += Time.deltaTime;
            timeScore.text = timeTaken.ToString("F2");
        }
    }

    //StopTimer Function
    #region StopTimer
    public void StopTimer()
    {
        timerActive = false;

        //We load our previus best time to the current scene
        float previousBestTime = PlayerPrefs.GetFloat(scenesIdentifier + "HighScore", float.MaxValue);

        //if timeTaken is less the previousBestTime the set our/save out new best time to PlayerPrefs.SetFloat
        if (timeTaken < previousBestTime)
        {
            // Update and save the best time for the current scene
            highScore.text = timeTaken.ToString("F2");
            PlayerPrefs.SetFloat(scenesIdentifier + "HighScore", timeTaken);
        }
    }
    #endregion
    
}
