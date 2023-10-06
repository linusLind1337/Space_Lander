using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastScene : MonoBehaviour
{
    UI_Manager uiManager;
    test _test;

    public gameOver winningMenu;

    private void Awake()
    {
        uiManager = FindFirstObjectByType<UI_Manager>();
        _test = FindFirstObjectByType<test>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Finisher"))
        {
            if (uiManager.onLastScene())
            {
                DisplayWinnigScreen();
                _test.StopTimer();
                uiManager.displayBestTime();
                Debug.Log("onLastScene called");
            }
            Debug.Log("Player Collided");
        }
    }

    void DisplayWinnigScreen()
    {
        Debug.Log("WinningMenu pop up");
       // winningMenu.gameObject.SetActive(true);
      //  Time.timeScale = 0f;
    }
}
