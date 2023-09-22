using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public Transform playerObj;
    public Camera mainCam;
    public float speed;

    private Vector3 target;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Awake()
    {
        mainCam = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (playerObj != null)
        {
            //Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            target = mainCam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 Dir = target - playerObj.transform.position;
            target.z = 0f;
            float angles = MathF.Atan2(Dir.x, Dir.y) * Mathf.Rad2Deg;

            angles = angles >= 45f ? 45 : (angles <= -45 ? -45f : angles);

            transform.rotation = Quaternion.AngleAxis(-angles, Vector3.forward);

            if (Input.GetKey(KeyCode.Mouse0))
            {
                rb2d.gravityScale = 0;
                transform.position = Vector3.MoveTowards(playerObj.position, target, speed * Time.deltaTime);

            }


        }

        

    }
}
