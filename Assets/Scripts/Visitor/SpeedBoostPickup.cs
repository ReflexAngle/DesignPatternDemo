using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SpeedBoostPickup : MonoBehaviour, IPickupVisitable
{
    // Implement the AcceptPickup method from the IPickupVisitable interface
    // Start is called before the first frame update
    public float speedMultiplier = 1.5f; // Speed multiplier for the speed boost pickup
    public float duration = 5f; // Duration of the speed boost
    void Awake(){
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.isTrigger = true; // Set the collider to be a trigger
        }else
        {
            Debug.LogError("Collider2D component not found on the SpeedBoost object.");
        }
        
    }
    public void AcceptPickup(IPickupVisitor visitor)
    {
        visitor.Visit(this); // Accept the pickup visitor
        Destroy(gameObject); // Destroy the pickup object after being accepted
    }
}
