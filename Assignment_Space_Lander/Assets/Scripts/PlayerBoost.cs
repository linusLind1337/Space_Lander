using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
    /* [Header("Fuel settings")]
     public float currentBoostFuel;
     public float maxBoostFuel;
     [SerializeField] private float usingFuelAmount;
     [Space]

     [Header("Booleans")]
     public bool canPlayerBoost;
     [Space]

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

     public void Boosting()
     {
         // if currentBoostFuel > 0 then we call _player functions to handle our boost, else we cant boost
         if ( currentBoostFuel> 0)
         {
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
             //_player.psFire.Stop();
         }

         // if currentBoostFuel >= maxboostFuel then we cant get more fuel
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
             currentBoostFuel  = maxBoostFuel;

         }
     }

     #endregion*/

    [Header("Fuel settings")]
    public float currentBoostFuel;
    public float maxBoostFuel;
    [SerializeField] private float usingFuelAmount;
    [Space]

    [Header("Booleans")]
    public bool canPlayerBoost;
    public bool isInfiniteBoostActive = false; // New variable
    private float infiniteBoostDuration = 3.0f; // Duration of infinite boost
    private float infiniteBoostTimer = 0.0f; // Timer for infinite boost

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
        isInfiniteBoostActive = true;
        infiniteBoostTimer = infiniteBoostDuration;
    }

    public void Boosting()
    {
        if (isInfiniteBoostActive)
        {
            if (infiniteBoostTimer > 0)
            {
                // Handle infinite boost here
                _player.UserInput();
                _player.UpdatePos();
                _player.Boosting();
                infiniteBoostTimer -= Time.deltaTime;
            }
            else
            {
                // Infinite boost duration is over, deactivate it
                isInfiniteBoostActive = false;
            }
        }
        else if (currentBoostFuel > 0)
        {
            // Your regular boost logic
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
