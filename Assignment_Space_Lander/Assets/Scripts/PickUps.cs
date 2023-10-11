using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    PlayerBoost _boost;
    public List<GameObject> pickupObj;
    public PlayerBoost playerBoost;

    private void Start()
    {
        _boost = FindFirstObjectByType<PlayerBoost>();
   
        foreach (Transform obj in transform)
        {
            pickupObj.Add(obj.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (pickupObj.Count > 0)
            {
                GameObject nextPickup = pickupObj[0];
                playerBoost.ActivateInfiniteBoost();
                Destroy(nextPickup);
                pickupObj.RemoveAt(0);
            }
        }
    }
}
