using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupHandler : MonoBehaviour, IPickupVisitor
{
    private PlayerControllerRefactored playerController; // Reference to the PlayerController script
    private float originalSpeed;
    private Coroutine speedBoostCoroutine; // Coroutine reference for speed boost
    void Awake(){
        playerController = GetComponent<PlayerControllerRefactored>(); // Get the PlayerController component
        if (playerController == null)
        {
            Debug.LogError("PlayerController component not found on the PickupHandler object.");
        }
        if (playerController != null)
        {
            originalSpeed = playerController.moveSpeed; // Store the original speed of the player
        }
    }
    public void Visit(SpeedBoostPickup pickup){
        if (playerController != null)
        {
            if (speedBoostCoroutine != null)
            {
                StopCoroutine(speedBoostCoroutine); // Stop any existing speed boost coroutine
            }
            speedBoostCoroutine = StartCoroutine(SpeedBoostCoroutine(pickup.speedMultiplier, pickup.duration)); // Start a new speed boost coroutine
        }
        Destroy(pickup.gameObject); // Destroy the pickup object after applying the effect
    }
    public void Visit(HealthPickup pickup){
        Debug.Log("Health pickup collected!"); // Log health pickup collection
        Destroy(pickup.gameObject); // Destroy the pickup object after applying the effect
    }
    private IEnumerator SpeedBoostCoroutine(float speedMultiplier, float duration){
        originalSpeed = playerController.moveSpeed; // Store the original speed
        playerController.moveSpeed *= speedMultiplier; // Apply the speed boost
        yield return new WaitForSeconds(duration); // Wait for the duration of the speed boost
        playerController.moveSpeed = originalSpeed; // Reset the speed back to original
        Debug.Log("Speed boost ended!"); // Log the end of the speed boost
        speedBoostCoroutine = null; // Clear the coroutine reference

    }
    void OnTriggerEnter2D(Collider2D other){
        IPickupVisitable pickup = other.GetComponent<IPickupVisitable>(); // Check if the collided object has the IPickupVisitable interface
        if (pickup != null)
        {
            pickup.AcceptPickup(this); // Accept the pickup visitor
        }
    }

}
