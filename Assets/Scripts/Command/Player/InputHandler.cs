using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerControllerRefactored  playerController; // Reference to the player controller
    void Awake()
    {
        if(playerController == null){
            Debug.LogError("PlayerController reference is not set in the InputHandler script.");
            enabled = false; // Disable the script if the reference is not set
        }
    }
    void Update()
    {
        if (playerController == null) return; // Check if playerController is not null

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(moveX, moveY);

        IPlayerInputCommand moveCommand = new MoveCommand(moveDirection);
        moveCommand.Execute(playerController); // Execute the move command

        // handle the rotation of the player
        if (Camera.main != null)
            {
                Vector3 mouseScreenPosition = Input.mousePosition;
                // Set a Z distance from the camera (important for ScreenToWorldPoint in 2D/orthographic)
                mouseScreenPosition.z = Camera.main.nearClipPlane + 10; // Adjust Z as needed
                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

                // Calculate direction from player to mouse
                Vector2 rotateDirection = (mouseWorldPosition - playerController.transform.position).normalized;

                 // Create and execute Rotate Command
                IPlayerInputCommand rotateCommand = new RotateCommand(rotateDirection);
                rotateCommand.Execute(playerController);
            }
            else
            {
                 Debug.LogWarning("Main Camera not found, cannot perform rotation.", this);
            }
            // handle the shooting of the player
            if (Input.GetButtonDown("Fire1")) // Check if the fire button is pressed
            {
                IPlayerInputCommand shootCommand = new ShootCommand(); // Create a new shoot command
                shootCommand.Execute(playerController); // Execute the shoot command
            }



    }
}
