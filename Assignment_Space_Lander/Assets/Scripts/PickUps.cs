using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public GameObject activateShield;
    private bool isShieldActive;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ActiveShieldTimer());
        }
    }

    //Add fucntion for sheild
    
    IEnumerator ActiveShieldTimer()
    {
        isShieldActive = true;
        activateShield.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        isShieldActive = false;
        activateShield.gameObject.SetActive(false);

    }
}
