using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public TMP_Text healthText;

    public List<GameObject> activeShields = new List<GameObject>();

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

    public void HealthManager()
    {
        if (gameObject != null)
        { 
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

    public void ShieldActivate()
    {
        isShieldActive = true;
        foreach (var shield in activeShields)
        {
            shield.SetActive(true);
        }
    }

    public void ShieldDeActivate()
    {
        isShieldActive = false;
        foreach (var shield in activeShields)
        {
            if (shield != null) // Check for null reference
            {
                shield.SetActive(false);
            }
        }
    }
}
