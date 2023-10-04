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
   // public Rigidbody2D rb2d;

    private void Update()
    {   
        if (player != null && Vector2.Distance(transform.position, player.position) < shootDist)
        {
            
            if (Time.time - lastShotTimeCounter >= shootInterval)
            {
                Shoot();
                lastShotTimeCounter = Time.time;
            }
        }
    }

    private void Shoot()
    {
        // Instantiate and shoot a bullet towards the player.
        GameObject bullets = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector2 direction = (player.position - transform.position).normalized;

        bullets.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        
    }
}
