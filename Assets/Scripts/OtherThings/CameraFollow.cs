using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; // Reference to the player's transform
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10); // Offset from the player
    [SerializeField] private float smoothSpeed = 0.125f; // Smoothness of the camera movement

    void LateUpdate()
    {
        if (playerTransform == null)
        {
            Debug.LogWarning("Player Transform is not assigned to the CameraFollow script.");
            return;
        }

        // Calculate the desired position
        Vector3 desiredPosition = playerTransform.position + offset;

        // Smoothly interpolate to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;

        // Optionally, keep the camera looking at the player
        transform.LookAt(playerTransform);
    }
}
