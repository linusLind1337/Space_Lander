using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    PlayerBoost _playerBoost;
    PlayerRotate _playerRotate;

    public TMP_Text BoostText;
    public TMP_Text DistanceText;

    // Start is called before the first frame update
    void Awake()
    {
        _playerBoost = GameObject.FindFirstObjectByType<PlayerBoost>();
        _playerRotate = GameObject.FindFirstObjectByType<PlayerRotate>();
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
            BoostText.text = "Boost: " + _playerBoost.currentBoostFuel.ToString() + " / " + _playerBoost.maxBoostFuel.ToString();
            BoostText.text = "Boost: " + Mathf.Round(_playerBoost.currentBoostFuel).ToString() + " / " + Mathf.Round(_playerBoost.maxBoostFuel).ToString();

        }   
    }
}
