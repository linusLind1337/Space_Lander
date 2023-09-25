using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject camOne;

    public GameObject camtwo;
    // Start is called before the first frame update
    void Start()
    {
        camOne.gameObject.SetActive(true);
        camtwo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SecondCam"))
        {
            camOne.gameObject.SetActive(false);
            camtwo.gameObject.SetActive(true);
        }
    }
}
