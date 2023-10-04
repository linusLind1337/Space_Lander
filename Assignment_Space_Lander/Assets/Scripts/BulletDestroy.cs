using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
   [SerializeField] private float bulletDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bulletDistance);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
