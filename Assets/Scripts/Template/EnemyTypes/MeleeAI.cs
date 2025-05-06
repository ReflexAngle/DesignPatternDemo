using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAI : EnemyTemplate
{
    private PlayerHealthPublisher playerHealthPublisher;

    // Constructor to pass the enemy GameObject up to the base class
    public MeleeAI(GameObject enemy) : base(enemy) { }

    // Implement the abstract methods from the base class
    // This method finds the player in the scene
    protected override void FindPlayer()
    {
        // Implement logic to find the player
        // For example, you could use a tag or a specific GameObject reference
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player"); // Find the player by tag
            if (target != null)
            {
                playerHealthPublisher = target.GetComponent<PlayerHealthPublisher>(); // Get the PlayerHealthPublisher component
            }
        }
    }
    protected override void MoveTowardsPlayer(float deltaTime)
    {
        // Implement logic to move towards the player
        if (target != null && GetDistanceToPlayer() > attackRange)
        {
            Vector3 direction = (target.transform.position - enemyPrefab.transform.position).normalized;
            enemyPrefab.transform.position += direction * speed * deltaTime; // Move towards the player
        }
    }
    protected override void AttackIfInRange(float deltaTime)
    {
        // Implement logic to attack the player if in range
        if (target != null && GetDistanceToPlayer() <= attackRange && currentAttackCooldown <= 0f)
        {
            if (playerHealthPublisher != null)
            {
                playerHealthPublisher.takeDamage(10); // Deal 10 damage to the player
                Debug.Log("Enemy dealt 10 damage to the player.");
            }
            currentAttackCooldown = attackCooldown; // Reset the cooldown
        }
    }
}
