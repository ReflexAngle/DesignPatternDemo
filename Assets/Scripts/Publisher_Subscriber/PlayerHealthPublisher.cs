using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerHealthPublisher : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100; // Player's health
    public int currentHealth;
    public event Action<int, int> OnHealthChanged; // Event to notify subscribers about health changes
    public int CurrentHealth => currentHealth; // Property to get the current health

    void Awake()
    {
        currentHealth = maxHealth; // Initialize current health to max health
    }
    void Start()
    {
        PublishHealthChange(); // Notify subscribers about the initial health
    }
    public void takeDamage(int damageAmount)
    {
        if (currentHealth <= 0) return; // If already dead, do nothing

        currentHealth -= damageAmount; // Reduce health by damage amount
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't go below 0

        Debug.Log($"Player took {damageAmount} damage. Current health: {currentHealth}");

        PublishHealthChange(); // Notify subscribers about the health change

        if (currentHealth <= 0)
        {
            HandleDeath(); // Handle player death
        }

        
    }
    public void Heal(int healAmount)
    {
        if ( currentHealth <= 0) return; // If already dead, do nothing

        currentHealth += healAmount; // Increase health by heal amount
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't exceed max health
        Debug.Log($"Player healed {healAmount} health. Current health: {currentHealth}");

        PublishHealthChange(); // Notify subscribers about the health change
    }

    private void PublishHealthChange(){
        // Notify all subscribers about the health change
        OnHealthChanged?.Invoke(currentHealth, maxHealth); // Pass current and max health to subscribers
    }   
    private void HandleDeath(){
        Destroy(gameObject); // Destroy the player object
    }
    private void ResetHealth(){
        currentHealth = maxHealth; // Reset health to max health
        PublishHealthChange(); // Notify subscribers about the reset
        Debug.Log("Player health reset to max.");
    }

}
