using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTemplate 
{
    protected GameObject enemyPrefab; // Prefab of the enemy
    protected GameObject target;
    protected float speed = 5f; // Speed of the enemy
    protected float attackRange = 1.5f;
    protected float attackCooldown = 1f; // Time between attacks
    protected float currentAttackCooldown = 0f; // Time left until next attack

    public EnemyTemplate(GameObject enemy)
    {
        this.enemyPrefab = enemy;
    }
    public void UpdateBehavior(float deltaTime)
    {

        FindPlayer(); // Calls the specific implementation from the subclass

        // If we don't have a target, maybe do nothing else
        if (target == null)
        {
            MoveTowardsPlayer(deltaTime); // Calls the specific implementation
            AttackIfInRange(deltaTime); // Calls the specific implementation
            UpdateCooldowns(deltaTime); // Can be concrete here or virtual/abstract
        }

        MoveTowardsPlayer(deltaTime); // Calls the specific implementation

        AttackIfInRange(deltaTime); // Calls the specific implementation

        UpdateCooldowns(deltaTime); // Can be concrete here or virtual/abstract
    }

    protected abstract void FindPlayer();
    protected abstract void MoveTowardsPlayer(float deltaTime);
    protected abstract void AttackIfInRange(float deltaTime);

    protected virtual void UpdateCooldowns(float deltaTime)
    {
        if (currentAttackCooldown > 0)
        {
            currentAttackCooldown -= deltaTime;
        }
    }

    // Helper to get distance (could be abstract if calculation varies)
    protected virtual float GetDistanceToPlayer()
    {
        if (target == null) return float.MaxValue;
        // Replace with actual Vector distance calculation in your engine
        return Vector3.Distance(enemyPrefab.transform.position, target.transform.position);
    }
    // when the enemy dies, it will drop a potential item
    private void OnDeathDropPotential(){

    }

}
