using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.SceneManagement;

public class PlayerDetecter : MonoBehaviour
{
    [Header("Player Reference")]
    public GameObject Player;
    [Space]

    [Header("Boolean")]
    public bool isPlayerDead;

    //CollisionEnter2D Function
    #region CollisionEnter2D
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (!isPlayerDead)
        {
            isPlayerDead = true;
            StartCoroutine(KillPlayerOnColl());
        }
    }
    #endregion

    //IEnumerator
    #region IEnumerator
    public IEnumerator KillPlayerOnColl()
    {
        Destroy(Player);
        yield return new WaitForSeconds(.3f);
        Time.timeScale = 0f;
    }
    #endregion

}
