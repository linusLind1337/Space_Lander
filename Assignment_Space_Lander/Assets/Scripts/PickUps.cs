using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    PlayerBoost _boost;
    // List of pickup objects
    public List<GameObject> pickupObjects;
    // Reference to the player's boost handler script
    public PlayerBoost playerBoost;

    private void Start()
    {
        _boost = FindFirstObjectByType<PlayerBoost>();

        // Populate the list of pickup objects at the start
        foreach (Transform child in transform)
        {
            pickupObjects.Add(child.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (pickupObjects.Count > 0)
            {
                // Activate the next pickup in the list
                GameObject nextPickup = pickupObjects[0];
                playerBoost.ActivateInfiniteBoost();

                // Destroy the pickup object
                Destroy(nextPickup);
                pickupObjects.RemoveAt(0);
            }
        }
    }
}
