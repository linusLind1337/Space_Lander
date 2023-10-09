using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
   [SerializeField] private float bulletDistance;
    
    // Start is called before the first frame update
    void Start()
    {//Destory bullet after bulletDistance aka x amount of seconds
        Destroy(gameObject, bulletDistance);
    }

    //OnTriggerEnter2D Function
    #region TriggerEnter2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if object collides with any of them = destory(gameObject)
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
    #endregion

}
