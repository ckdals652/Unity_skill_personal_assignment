using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseAim : MonoBehaviour
{
    [Header("MouseAim")] public Transform playerCameraTransform;
    public float minXLook;
    public float maxXLook;
    private float currentXRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;


    private void LateUpdate()
    {
        CameraAim();
    }

    private void CameraAim()
    {
        currentXRot += mouseDelta.y * lookSensitivity;
        currentXRot = Mathf.Clamp(currentXRot, minXLook, maxXLook);
        playerCameraTransform.localEulerAngles = new Vector3(currentXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    void OnAim(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
}