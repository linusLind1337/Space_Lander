using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
    public float currentBoostFuel;
    public float maxBoostFuel;

    public bool canPlayerBoost;

    private PlayerRotate _player;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        currentBoostFuel = maxBoostFuel;
        _player = GameObject.FindFirstObjectByType<PlayerRotate>();
        _rigidbody = GameObject.FindFirstObjectByType<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Boosting();
    }

    public void Boosting()
    {
        if (currentBoostFuel > 0)
        {
            _player.UserInput();
            _player.UpdatePos();
            if (_player.isPlayerBoosting)
            {
                _player.Boosting();
                currentBoostFuel -= Time.deltaTime * 10;
            }
        }
        else
        {
            _player.isPlayerBoosting = false;
            _rigidbody.gravityScale = 1f;
        }
        
    }
}
