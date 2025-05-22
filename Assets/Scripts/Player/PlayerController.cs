using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


public class PlayerController : MonoBehaviour
{
    [Header("Movement")] public float MovementSpeed;
    public float jumpForce;

    public Vector2 currentMovementInput;

    //플레이어 콜라이더 좌측 하단 기준
    public Transform playerBottomPosition;
    private Collider playerCollider;
    [FormerlySerializedAs("rayLength")] public float groundRayLength = 0.2f;
    public LayerMask groundLayer;
    public Ray[] groundRays = new Ray[9];

    private Rigidbody playerRigidbody;


    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
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

    //플레이어 이동
    public void Move()
    {
        Vector3 direction = transform.forward * currentMovementInput.y + transform.right * currentMovementInput.x;
        direction *= MovementSpeed;
        direction.y = playerRigidbody.velocity.y;

        playerRigidbody.velocity = direction;
    }

    //점프
    public void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded() && context.phase == InputActionPhase.Started)
        {
            playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }

    //땅인지 확인하기
    public bool isGrounded()
    {
        GenerateGroundRays();
        foreach (var ray in groundRays)
        {
            if (Physics.Raycast(ray, groundRayLength, groundLayer))
            {
                return true;
            }
        }

        return false;
    }

    //땅 확인용 레이 위치 최신화
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

                Vector3 origin = center + new Vector3(offsetX, 0.01f, offsetZ);
                groundRays[index] = new Ray(origin, Vector3.down);
                index++;
            }
        }
    }
    //땅 확인 레이 시각화
    void OnDrawGizmos()
    {
        if (groundRays == null) return;

        Gizmos.color = Color.cyan;

        foreach (Ray ray in groundRays)
        {
            Gizmos.DrawRay(ray.origin, ray.direction * groundRayLength);
        }
    }
}