using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    /*public GameObject activateShield;
    private bool isShieldActive;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ActiveShieldTimer());
        }
    }

    //Add function for shield
    
    IEnumerator ActiveShieldTimer()
    {
        isShieldActive = true;
        activateShield.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        isShieldActive = false;
        activateShield.gameObject.SetActive(false);

    }*/

    public Health playerHealth; // Reference to the player's Health script
    public GameObject activateShield;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Activate the shield in the player's Health script
            StartCoroutine(ActiveShieldTimer());
            playerHealth.ShieldActivate();
           
        }
    }

    IEnumerator ActiveShieldTimer()
    {
        activateShield.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        playerHealth.ShieldDeActivate();
        playerHealth.isShieldActive = false;
        activateShield.gameObject.SetActive(false);
    }

}
