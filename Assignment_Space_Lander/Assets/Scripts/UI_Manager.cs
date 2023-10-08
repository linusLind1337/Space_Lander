using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class UI_Manager : MonoBehaviour
{
    [Header("Text UI")]
    public TMP_Text BoostText;

    public GameObject gameOverObj;
    public GameObject WinningObj;
    public GameObject pauseObj;

    private bool isGamePaused;

    [Space]

    //References
    PlayerBoost _playerBoost;
    PlayerRotate _playerRotate;
    PlayerDetecter _playerDetecter;
    Health _health;

    // Start is called before the first frame update
    void Awake()
    {
        _playerBoost = FindFirstObjectByType<PlayerBoost>();
        _playerRotate = FindFirstObjectByType<PlayerRotate>();
        _playerDetecter = FindFirstObjectByType<PlayerDetecter>();
        _health = FindFirstObjectByType<Health>();

        if (_playerBoost == null || _playerRotate == null || _playerDetecter == null || _health == null)
        {
            Debug.LogError("One or more required components are missing.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePause();
        }

        GUIUpdate();   
    }


    private void GUIUpdate()
    {
        isPlayerDead();

        if (BoostText != null)
        {
            BoostText.text = "Boost: " + Mathf.Round(_playerBoost.currentBoostFuel).ToString() + " / " + Mathf.Round(_playerBoost.maxBoostFuel).ToString();
        }  
    }


    public void isPlayerDead()
    {
         if (_playerDetecter.isPlayerDead)
         {
             gameOverObj.gameObject.SetActive(true);
         }
         else if (_health.currentHealth <= 0)
         {
             _health.HealthManager();
             _health.healthText.gameObject.SetActive(false);
             Destroy(_health.gameObject);
             Time.timeScale = 0f;
             gameOverObj.gameObject.SetActive(true);

         }
    }

    public void gamePause()
    {
        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? 0f : 1f;
        pauseObj.gameObject.SetActive(isGamePaused);
    }

}
