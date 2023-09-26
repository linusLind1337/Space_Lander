using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class PlayerRotate : MonoBehaviour
{
    [Header("Boost Settings")]
    public float boostSpeed;
    public float counterXForce;

    [Header("Ground check")]
    public bool isPlayerBoosting;
    public bool isGrounded;
    private bool boostEnabled;

    [Header("GroundLayer")]
    public LayerMask GroundLayer;

    [Header("References")]
    public Transform playerObj;
    public ParticleSystem ps;
    private Camera mainCam;
    private Vector3 target;
    private Vector2 distance;
    private Rigidbody2D rb2d;
    private Quaternion originalRot;

    private PlayerBoost _Boost;


    // Start is called before the first frame update
    void Awake()
    {
        mainCam = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 1f;
        originalRot = transform.rotation;
        _Boost = GameObject.FindFirstObjectByType<PlayerBoost>();
    }

    // Update is called once per frame
    public void Update()
    {
        UpdatePos();
        Grounded();
        UserInput();
    }

    public void UserInput()
    {
        if (Input.GetMouseButtonDown(0) && !boostEnabled)
        {
            EnableBoost();
            ps.Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            DisableBoost();
            ps.Stop();
        }

        if (isPlayerBoosting)
        {
            Boosting();
        }
    }

    public void UpdatePos()
    {
        if (playerObj != null)
        {
            target = mainCam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 Dir = target - playerObj.transform.position;
            target.z = 0f;
            float angles = MathF.Atan2(Dir.x, Dir.y) * Mathf.Rad2Deg;

            angles = angles >= 45f ? 45 : (angles <= -45 ? -45f : angles);

            if (!isGrounded)
            {
                transform.rotation = Quaternion.AngleAxis(-angles, Vector3.forward);
            }
        }
    }

    public void EnableBoost()
    {
        isPlayerBoosting = true;
        rb2d.gravityScale = 0f;
        isGrounded = false;
        boostEnabled = true;
        _Boost.canPlayerBoost = true;

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

        Vector3 Direction = (target - transform.position);
        rb2d.AddForce(Direction * boostSpeed);
        _Boost.canPlayerBoost = false;

    }

    public void Grounded()
    {
        if (!isGrounded)
        {
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

}
