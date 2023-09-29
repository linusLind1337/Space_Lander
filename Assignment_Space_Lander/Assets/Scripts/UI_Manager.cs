using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    PlayerBoost _playerBoost;
    PlayerRotate _playerRotate;
    PlayerDetecter _playerDetecter;

    public TMP_Text BoostText;
    public TMP_Text TimerText;
    public GameObject gameOverObj;
    

    // Start is called before the first frame update
    void Awake()
    {
        _playerBoost = FindFirstObjectByType<PlayerBoost>();
        _playerRotate = FindFirstObjectByType<PlayerRotate>();
        _playerDetecter = FindFirstObjectByType<PlayerDetecter>();


    }

    private void Start()
    {
        TimerText.text = "Timer: " + Time.time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GUIUpdate();
    }

    private void GUIUpdate()
    {
        if (BoostText != null)
        {
            //BoostText.text = "Boost: " + _playerBoost.currentBoostFuel.ToString() + " / " + _playerBoost.maxBoostFuel.ToString();
            BoostText.text = "Boost: " + Mathf.Round(_playerBoost.currentBoostFuel).ToString() + " / " + Mathf.Round(_playerBoost.maxBoostFuel).ToString();

        }
        if (_playerDetecter.isPlayerDead)
        {
            gameOverObj.gameObject.SetActive(true);
        }


    }
}
