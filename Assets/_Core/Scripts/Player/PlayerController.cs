using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float CameraClamp;
    public float Smooth;
    
    private float rotX;
    private float rotY;
    private float sens = 5f;

    private void Update()
    {
        CameraController();
    }

    void CameraController()
    {
        rotY -= Input.GetAxis("Mouse X") * sens;
        rotX += Input.GetAxis("Mouse Y") * sens;
        
        rotX = Mathf.Clamp(rotX, -CameraClamp, CameraClamp);
        rotY = Mathf.Clamp(rotY, -CameraClamp, CameraClamp);
        
        Quaternion _target = Quaternion.Euler(-rotX, -rotY, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, _target, Time.deltaTime * Smooth);
    }
}
