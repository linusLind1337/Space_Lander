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
    private float infiniteBoostTimer = 0.0f; // Infinite boost timer
    private float infiniteBoostDuration = 3.0f; // infinite boost durations
    [Space]

    [Header("Booleans")]
    public bool canPlayerBoost;
    public bool isInfiniteBoostActive = false;

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

    public void ActivateInfiniteBoost()
    {
        //Sets boost timer to boost duration if true
        isInfiniteBoostActive = true;
        infiniteBoostTimer = infiniteBoostDuration;
    }

    public void Boosting()
    {
        if (isInfiniteBoostActive)
        {
            if (infiniteBoostTimer > 0)
            {
                // Handles our infinite boost
                _player.UserInput();
                _player.UpdatePos();
                _player.Boosting();
                infiniteBoostTimer -= Time.deltaTime;
            }
            else
            {
                // if Infinite boost over, deActivate it
                isInfiniteBoostActive = false;
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
