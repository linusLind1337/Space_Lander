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
               // healthText.gameObject.SetActive(false);
                Destroy(gameObject);
            }
            healthText.text = "Health: " + currentHealth + " / " + maxHealth;
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            float randDam = Random.Range(30, 40);

            currentHealth -= randDam;

            HealthManager();
        }
    }
}
