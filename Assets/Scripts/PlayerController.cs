using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Header("Movement")] public float MovementSpeed;
    public float jumpForce;

    public Vector2 currentMovementInput;

    //플레이어 콜라이더 좌측 하단 기준
    public Transform playerBottomPosition;
    private Collider playerCollider;
    public float rayLength = 0.1f;
    public LayerMask groundLayer;
    public Ray[] groundRays = new Ray[9];

    private Rigidbody playerRigidbody;


    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        //땅인지 확인할 레이 쏘기
        GenerateGroundRays();
    }

    void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
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

    public void Move()
    {
        Vector3 direction = transform.forward * currentMovementInput.y + transform.right * currentMovementInput.x;
        direction *= MovementSpeed;
        direction.y = playerRigidbody.velocity.y;

        playerRigidbody.velocity = direction;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
    }

    public void isGrounded()
    {
        foreach (var ray in groundRays)
        {
            
        }
    }

    public void GenerateGroundRays()
    {
        Bounds bounds = playerCollider.bounds;
        float width = bounds.size.x;
        float depth = bounds.size.z;

        int index = 0;
        int gridCount = 3;
        float xSpacing = width / (gridCount - 1);
        float zSpacing = depth / (gridCount - 1);

        Vector3 center = playerBottomPosition.position;

        for (int x = 0; x < gridCount; x++)
        {
            for (int z = 0; z < gridCount; z++)
            {
                float offsetX = -width / 2f + x * xSpacing;
                float offsetZ = -depth / 2f + z * zSpacing;

                Vector3 origin = center + new Vector3(offsetX, 0f, offsetZ);
                groundRays[index] = new Ray(origin, Vector3.down);
                index++;
            }
        }
    }
}