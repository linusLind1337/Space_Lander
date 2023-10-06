using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class test : MonoBehaviour
{
    [Header("Text UI")]
    public TMP_Text BoostText;
    public TMP_Text CurrentTimeText;
    public TMP_Text BestTimeText;

    private float timeElapsed;
    private float bestTimer = float.MaxValue;

    private string bestTimeSavePath = "bestTime.txt"; // The file path for saving best time

    // ... Other variables and references ...

    void Awake()
    {
        // Initialize bestTimer from the saved file, or use float.MaxValue as the default value.
        if (System.IO.File.Exists(bestTimeSavePath))
        {
            bestTimer = float.Parse(System.IO.File.ReadAllText(bestTimeSavePath));
        }
    }

    void Update()
    {
        GUIUpdate();
    }

    private void GUIUpdate()
    {
        // ... Update BoostText, Timer, and other UI elements ...
        Timer();
        displayBestTime();
    }

    public void Timer()
    {
        // ... Update timeElapsed ...

        if (timeElapsed < bestTimer)
        {
            bestTimer = timeElapsed;

            // Save the best time to the file
            System.IO.File.WriteAllText(bestTimeSavePath, bestTimer.ToString());
        }
    }

    public void displayBestTime()
    {
        int bestMin = Mathf.FloorToInt(bestTimer / 60);
        int bestSec = Mathf.FloorToInt(bestTimer % 60);
        BestTimeText.text = string.Format("Best time: {0:00}:{1:00}", bestMin, bestSec);
    }
}
