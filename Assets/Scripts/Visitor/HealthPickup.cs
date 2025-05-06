using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HealthPickup : MonoBehaviour, IPickupVisitable
{
    private int healthAmount = 15; // Amount of health to restore
    private PlayerHealthPublisher playerHealthPublisher; // Reference to the player health publisher

    void Awake(){
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.isTrigger = true; // Set the collider to be a trigger
        }else
        {
            Debug.LogError("Collider2D component not found on the HealthPickup object.");
        }

    }
    public void AcceptPickup(IPickupVisitor visitor)
    {
        visitor.Visit(this); // Accept the pickup visitor
        playerHealthPublisher.Heal(healthAmount); // Increase the player's health by the pickup amount

        Destroy(gameObject); // Destroy the pickup object after being accepted
    }
}
