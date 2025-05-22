using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseAim : MonoBehaviour
{
    [Header("MouseAim")] 
    public Transform Player;
    public Transform playerCameraTransform;
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
        currentXRot -= mouseDelta.y * lookSensitivity;
        currentXRot = Mathf.Clamp(currentXRot, minXLook, maxXLook);
        //카메라만 위아래 각도 돌리기
        playerCameraTransform.localEulerAngles = new Vector3(currentXRot, 0, 0);
        //player객체 전체 좌우 돌리기
        Player.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
}