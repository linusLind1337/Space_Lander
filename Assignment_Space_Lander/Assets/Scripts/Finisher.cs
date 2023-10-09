using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finisher : MonoBehaviour
{
    //References
    Timer _timer;
    UI_Manager _uiManager;

    [Header("Winning Menu")]
    public gameOver winningMenu;

    private void Awake()
    {
        _timer = FindFirstObjectByType<Timer>();
        _uiManager = FindFirstObjectByType<UI_Manager>();
    }

    //OnCollision2D Function
    #region Collision2D
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if player collides with "Finisher" then stop timer and display winningScreen
        if (other.gameObject.CompareTag("Finisher"))
        {
            _uiManager.DisplayWinnigScreen();
            _timer.StopTimer();
            Debug.Log("Player Collided");
        }
    }
    #endregion

}
