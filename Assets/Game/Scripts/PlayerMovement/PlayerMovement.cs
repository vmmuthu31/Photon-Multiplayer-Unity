using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;
    Vector3 moveDirection;
    Transform cameragameObject;
    Rigidbody playerRigidbody;

    public float movementSpeed = 2f;
    public float rotationSpeed = 13f;

    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameragameObject = Camera.main.transform;

        // Error checking
        if (inputManager == null)
        {
            Debug.LogError("InputManager component not found on the GameObject.");
        }
        if (playerRigidbody == null)
        {
            Debug.LogError("Rigidbody component not found on the GameObject.");
        }
        if (cameragameObject == null)
        {
            Debug.LogError("Main camera not found in the scene.");
        }
    }

    public void HandleAllMovement()
    {
        HandleRotation();
        HandleMovement();
    }

    void HandleMovement()
    {
        moveDirection = cameragameObject.forward * inputManager.vertical + cameragameObject.right * inputManager.horizontal;
        moveDirection.y = 0;
        moveDirection.Normalize();

        Vector3 movementVelocity = moveDirection * movementSpeed;
        playerRigidbody.velocity = movementVelocity;
    }

    void HandleRotation()
    {
        Vector3 targetDirection = cameragameObject.forward * inputManager.vertical + cameragameObject.right * inputManager.horizontal;
        targetDirection.y = 0;
        targetDirection.Normalize();

        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
