using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cinemachineController : MonoBehaviour
{
    public float maxXValue;
    public float minXValue;

    [SerializeField]private Transform cmCameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        cmCameraTransform = GetComponent<CinemachineVirtualCamera>().transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (cmCameraTransform.position.x > maxXValue)
        {
            Vector3 pos = cmCameraTransform.position;
            pos.x = maxXValue;
            cmCameraTransform.position = pos;
        }
        else if (cmCameraTransform.position.x < minXValue)
        {
            Vector3 pos = cmCameraTransform.position;
            pos.x = minXValue;
            cmCameraTransform.position = pos;
        }
    }
}
