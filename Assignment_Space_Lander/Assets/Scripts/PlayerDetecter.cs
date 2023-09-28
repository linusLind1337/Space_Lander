using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.SceneManagement;

public class PlayerDetecter : MonoBehaviour
{
    public GameObject Player;
    private bool hasPlayerCollided;
    private bool isPlayerDead;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        hasPlayerCollided = true;
        isPlayerDead = false;
        if (hasPlayerCollided)
        {
            isPlayerDead = true;
            StartCoroutine(KillPlayerOnColl());
        }
       
    }

    IEnumerator KillPlayerOnColl()
    {
        Destroy(Player);
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(1);
        hasPlayerCollided = false;
        isPlayerDead = false;


    }
}
