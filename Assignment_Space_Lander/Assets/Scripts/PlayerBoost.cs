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

    #endregion
    
}
