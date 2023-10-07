using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastScene : MonoBehaviour
{
    test _test;

    public gameOver winningMenu;

    private void Awake()
    {
        _test = FindFirstObjectByType<test>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Finisher"))
        {
            DisplayWinnigScreen();
            _test.StopTimer();
            Debug.Log("Player Collided");
        }
    }

    void DisplayWinnigScreen()
    {
        Debug.Log("WinningMenu pop up");
        winningMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
