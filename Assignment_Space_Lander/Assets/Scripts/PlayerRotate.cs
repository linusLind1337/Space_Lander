using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class PlayerRotate : MonoBehaviour
{
    [Header("Boost Settings")]
    public float boostSpeed;
    public float counterXForce;
    [Space]
    
    [Header("Ground check")]
    public bool isPlayerBoosting;
    public bool isGrounded;
    private bool boostEnabled;
    [Space]
    
    public Transform psPos;
    
    [Header("GroundLayer")]
    public LayerMask GroundLayer;
    [Space]

    [Header("References")]
    public Transform playerObj;
    public ParticleSystem psFire; 
    private Camera mainCam;

    private Vector3 target;
    private Vector2 distance;
    private Quaternion originalRot;

    private Rigidbody2D rb2d;
    private PlayerBoost _Boost;
    
    // Start is called before the first frame update
    void Awake()
    {
        mainCam = Camera.main;
        
        originalRot = transform.rotation;

        rb2d = GetComponent<Rigidbody2D>();
        _Boost = FindFirstObjectByType<PlayerBoost>(); 

        rb2d.gravityScale = 1f;
        Time.timeScale = 1f;

    }

    // Update is called once per frame
    public void Update()
    {
        UpdatePos();
        Grounded();
        UserInput();
    }

    #region User inputs

    public void UserInput()
    {
        if (Input.GetMouseButtonDown(0) && !boostEnabled)
        {
            EnableBoost();
            psFire.Play();
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            DisableBoost();
           psFire.Stop();
        }
        // if isPlayerBoosting call boosting(), which adds force to our target pos;
        if (isPlayerBoosting)
        {
            UpdatePos();
            Boosting();
            
        }
    }

    #endregion
    
    #region Player position update

    public void UpdatePos()
    {
        if (playerObj != null)
        {
            //Get players mousePos to worldPoint
            target = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 Dir = target - playerObj.transform.position;
            target.z = 0f;
            float angles = MathF.Atan2(Dir.x, Dir.y) * Mathf.Rad2Deg;
            //Sets the max angle for player to rotate, can rot max -45/45
            angles = angles >= 45f ? 45 : (angles <= -45 ? -45f : angles);
            //Applies rotation and vector.forward
            transform.rotation = Quaternion.AngleAxis(-angles, Vector3.forward);
            
            /*if (!isGrounded)
            {
                
            }*/
        }
    }

    #endregion

    #region PlayerBoost behavior
    
    public void EnableBoost() 
    {
        isPlayerBoosting = true;
        isGrounded = false;
        boostEnabled = true;
        _Boost.canPlayerBoost = true;
        rb2d.gravityScale = 0f;

        
    }
    public void DisableBoost()
    {
        isPlayerBoosting = false;
        boostEnabled = false;
        _Boost.canPlayerBoost = false;
        rb2d.gravityScale = 1f;
        
        //Counter force on X axis to smooth it in;
        Vector2 slowForce = -rb2d.velocity * counterXForce;
        rb2d.AddForce(slowForce, ForceMode2D.Force);
    }

    public void Boosting()
    {
        // A vector pointing from current pos to target pos;
        Vector3 Direction = (target - transform.position);
        rb2d.AddForce(Direction * boostSpeed);
        _Boost.canPlayerBoost = false;

    }

    #endregion

    #region Ground Checker

    public void Grounded()
    {
        if (!isGrounded)
        {
            // creates a RaycastHit2D on playerPos, checks if hit & distance is <= 1f, then set player to Grounded and freezeRot
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, GroundLayer);
            if (hit.collider != null && hit.distance <= 1f)
            {
                isGrounded = true;
                rb2d.freezeRotation = true;
                rb2d.gravityScale = 0f;
                Debug.DrawRay(distance, Vector2.down, Color.green);
                Debug.Log("Grounded");

            }
        }
        else
        {
            transform.rotation = originalRot;
        }
        
    }

    #endregion
    
}
