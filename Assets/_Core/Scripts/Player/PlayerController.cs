using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private Camera camera;
    private PlayerInput controls;
    
    public float CameraClamp;
    public float Smooth;
    public float CameraAngle;
    public float RayDistance;

    private Vector3 mousePos;
    private float rotX;
    private float rotY;
    private float sens = 5f;

    private void Start()
    {
        player = GetComponent<Player>();
        camera = GetComponent<Camera>();
        controls = GetComponent<PlayerInput>();

        InputAction _interact = controls.actions["Interact"];
        _interact.performed += InteractPerformed;
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
        mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = camera.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos * 100 - transform.position * 100, Color.red);
        if (Physics.Raycast(transform.position, mousePos * 100 - transform.position, out RaycastHit _hit, RayDistance))
        {
            if (_hit.collider.gameObject.TryGetComponent(out Interact _interact))
            {
                // shader graph and UI object interact
            }
        }
    }

    void InteractPerformed(InputAction.CallbackContext _ctx)
    {
        if (Physics.Raycast(transform.position, mousePos * 100 - transform.position, out RaycastHit _hit, RayDistance))
        {
            if (_hit.collider.gameObject.TryGetComponent(out Interact _interact))
            {
                _interact.Interaction(gameObject);
            }
        }
    }
}
