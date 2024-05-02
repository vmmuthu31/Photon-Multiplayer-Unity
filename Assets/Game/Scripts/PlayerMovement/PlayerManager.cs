using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerMovement playerMovement;

    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();

        // Ensure both components are attached to the GameObject
        if (inputManager == null)
        {
            Debug.LogError("InputManager component is not attached to the GameObject.");
        }
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement component is not attached to the GameObject.");
        }
    }

    void Update()
    {
        // Ensure the InputManager is not null before calling its methods
        if (inputManager != null)
        {
            inputManager.HandleAllMovement();
        }
    }

    void FixedUpdate()
    {
        // Ensure the PlayerMovement is not null before calling its methods
        if (playerMovement != null)
        {
            playerMovement.HandleAllMovement();
        }
    }
}
