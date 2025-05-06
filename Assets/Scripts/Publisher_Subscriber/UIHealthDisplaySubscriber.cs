using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI; // Assuming you are using TextMeshPro for UI text

public class UIHealthDisplaySubscriber : MonoBehaviour
{
    [SerializeField] private PlayerHealthPublisher playerHealthPublisher; // Reference to the health publisher
    [SerializeField] private Slider healthBar; // Reference to the health bar UI element
    //[SerializeField] private TMP_Text healthText; // Reference to the health text UI element
    // Start is called before the first frame update
    void Awake()
    {
        if (playerHealthPublisher == null)
        {
            Debug.LogError("PlayerHealthPublisher is not assigned in the inspector.");
            enabled = false; // Disable this script if the reference is not set
            return;
        }
        if (healthBar == null)
        {
            Debug.LogError("HealthBar is not assigned in the inspector.");

        }
    }
    void OnEnable(){
        if (playerHealthPublisher != null)
        {
            playerHealthPublisher.OnHealthChanged += HandleHealthChanged;
            // Immediately update UI with current health on enable
            HandleHealthChanged(playerHealthPublisher.CurrentHealth, playerHealthPublisher.maxHealth);
        }

    }
    void Disable()
    {
        if (playerHealthPublisher != null)
        {
            playerHealthPublisher.OnHealthChanged -= HandleHealthChanged;
        }
    }
    private void HandleHealthChanged(int currentHealth, int maxHealth)
    {
        
    
        // Update Slider
        if (healthBar != null)
        {
            // Ensure max value is set correctly (in case it changes)
            healthBar.maxValue = maxHealth;
            // Update the slider's current value
            healthBar.value = currentHealth;
        }

        
    }

}
