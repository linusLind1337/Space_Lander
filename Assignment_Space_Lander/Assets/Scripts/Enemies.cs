using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float shootDist = 10f;
    public float shootInterval = 1.0f;
    public float bulletSpeed;
    private float lastShotTimeCounter;
    [Space]

    [Header("References")]
    public Transform player;
    public GameObject bulletPrefab;
    public Transform bulletPoint;

    private void Update()
    {   //check if player is != null and distance is within shootDist
        if (player != null && Vector2.Distance(transform.position, player.position) < shootDist)
        {  //Check if enough time has passed
            if (Time.time - lastShotTimeCounter >= shootInterval)
            {
               //call Shoot()
                Shoot();
                //Update out last shot to our current timer(time.time)
                lastShotTimeCounter = Time.time;
            }
        }
    }

    //Shoot Function
    #region Shoot
    private void Shoot()
    {
        // Instantiate and shoot a bullet towards the player.
        GameObject bullets = Instantiate(bulletPrefab, bulletPoint.transform.position, Quaternion.identity);
        Vector2 direction = (player.position - transform.position).normalized;

        bullets.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

    }
    #endregion

}
