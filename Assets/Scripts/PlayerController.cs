using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float MovementSpeed;
    public Vector2 currentMovementInput;
    
    private Rigidbody playerRigidbody;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            currentMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            currentMovementInput = Vector2.zero;
        }
    }

    void Move()
    {
        Vector3 direction = transform.forward*currentMovementInput.y+transform.right*currentMovementInput.x;
        direction *= MovementSpeed;
        direction.y = playerRigidbody.velocity.y;

        playerRigidbody.velocity = direction;
    }
}