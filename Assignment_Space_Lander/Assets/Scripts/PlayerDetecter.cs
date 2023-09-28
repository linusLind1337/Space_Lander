using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.SceneManagement;

public class PlayerDetecter : MonoBehaviour
{
    public GameObject Player;
    public bool isPlayerDead;


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (!isPlayerDead)
        {
            isPlayerDead = true;
            StartCoroutine(KillPlayerOnColl());
        }

     /*   hasPlayerCollided = true;
        isPlayerDead = false;
        if (hasPlayerCollided)
        {
            isPlayerDead = true;  
            
            
        }*/
    }

    public IEnumerator KillPlayerOnColl()
    {
        Destroy(Player);
        yield return new WaitForSeconds(.3f);
        Time.timeScale = 0f;
    }
}
