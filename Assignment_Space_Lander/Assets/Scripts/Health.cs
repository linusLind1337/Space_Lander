using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    public float currentHealth;
    public float maxHealth;
    [Space]

    [Header("Reference")]
    public TMP_Text healthText;
    [Space]

    [Space]
    [Header("Shield checker")]
    public bool isShieldActive = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthManager();
    }

    //HealthManager Function
    #region HealthManager
    public void HealthManager()
    {
        if (gameObject != null) //We check for gameObject null reference
        {
            //if currentHealth is 0 and !isShieldActive then it destorys our player, else if isShieldActive true then dont take damage
            if (currentHealth == 0)
            {
                if (!isShieldActive)
                {
                    Destroy(gameObject);
                }

            }
            healthText.text = "Health: " + currentHealth + " / " + maxHealth;
        }

    }
    #endregion

    //OnTriggerEnter2D Function
    #region Trigger2D
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (!isShieldActive)
            {
                float randDam = Random.Range(30, 40);

                currentHealth -= randDam;

                HealthManager();
            }

        }
    }
    #endregion

}
