using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
  
    [Header("Fuel settings")]
    public float currentBoostFuel;
    public float maxBoostFuel;
    [SerializeField] private float usingFuelAmount;
    private float infiBoostTimer = 0.0f;
    private float infiBoostDuration = 3.0f;
    [Space]

    [Header("Booleans")]
    public bool canPlayerBoost;
    public bool isInfiniteActive = false;

    //References
    private PlayerRotate _player;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        currentBoostFuel = maxBoostFuel;
        _player = FindFirstObjectByType<PlayerRotate>();
        _rigidbody = FindFirstObjectByType<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Boosting();
    }

    //Fuel Function
    #region Tracking the fuel

    //Sets boost timer to boost duration if true
    public void ActivateInfiniteBoost()
    {
        isInfiniteActive = true;
        infiBoostTimer = infiBoostDuration;
    }

    public void Boosting()
    {
        //our infinite bost
        if (isInfiniteActive)
        {
            if (infiBoostTimer > 0)
            {  
                _player.UserInput();
                _player.UpdatePos();
                _player.Boosting();
                infiBoostTimer -= Time.deltaTime;
            }
            else
            {
                isInfiniteActive = false;
            }
        }
        else if (currentBoostFuel > 0)
        {
            // our normal boost
            _player.UserInput();
            _player.UpdatePos();

            if (_player.isPlayerBoosting)
            {
                _player.Boosting();
                currentBoostFuel -= Time.deltaTime * usingFuelAmount;
            }
        }
        else
        {
            _player.isPlayerBoosting = false;
            _rigidbody.gravityScale = 1f;
        }

        if (currentBoostFuel >= maxBoostFuel)
        {
            currentBoostFuel = maxBoostFuel;
        }
    }
    #endregion

    //Detector Function
    #region LandingPad detect

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("LandingPad"))
        {
            currentBoostFuel = maxBoostFuel;
        }
    }

    #endregion

}
