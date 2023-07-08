using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private Camera camera;
    
    public float CameraClamp;
    public float Smooth;
    public float CameraAngle;
    
    private float rotX;
    private float rotY;
    private float sens = 5f;

    private void Start()
    {
        player = GetComponent<Player>();
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        CameraController();
        if (player.IsMyTrun)
        {
            CameraInteraction();
        }
    }

    void CameraController()
    {
        rotY -= Input.GetAxis("Mouse X") * sens;
        rotX += Input.GetAxis("Mouse Y") * sens;
        
        rotX = Mathf.Clamp(rotX, -CameraClamp - CameraAngle, CameraClamp - CameraAngle);
        rotY = Mathf.Clamp(rotY, -CameraClamp, CameraClamp);
        
        Quaternion _target = Quaternion.Euler(-rotX, -rotY, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, _target, Time.deltaTime * Smooth);
    }

    void CameraInteraction()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = camera.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos * 100 - transform.position * 100, Color.red);
    }
}
