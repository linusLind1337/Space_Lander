using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [Header("References")]
    public Health playerHealth;
    public GameObject activateShield;

    //OnTriggerEnter Function
    #region Trigger2D
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            StartCoroutine(ActiveShieldTimer());
            playerHealth.ShieldActivate();//Activates shield from playerHealth

        }
    }
    #endregion

    //Shield IEnumerator
    #region Shield IEnum
    IEnumerator ActiveShieldTimer()
    {
        //Activates shield for 3 sec then deActivetes shield from gameObject and playerHealth
        activateShield.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        playerHealth.ShieldDeActivate();
        playerHealth.isShieldActive = false;
        activateShield.gameObject.SetActive(false);
    }
    #endregion


}
