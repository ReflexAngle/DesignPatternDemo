using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public int sqawnPointHealth = 80; // Health of the spawn point
    public GameObject enemyPrefab; // Prefab of the enemy to spawn
    public Transform spawnLocation; // Location where enemies will spawn

    private int rateOfGrowth = 1; // Number of additional enemies to spawn upon death

    void Start()
    {
        SpawnEnemy(); // Spawn the initial enemy
    }

    void Update()
    {
        // Optional: Add logic here if needed to manage enemies or spawn behavior
    }

    public void handleDestroy()
    {
        Destroy(gameObject); // Destroy the spawn point object
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab != null && spawnLocation != null)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, spawnLocation.position, Quaternion.identity);

            // Attach a death handler to the enemy
            EnemyDeathHandler deathHandler = newEnemy.GetComponent<EnemyDeathHandler>();
            if (deathHandler != null)
            {
                deathHandler.SetSpawnPoints(this);
            }
        }
        else
        {
            Debug.LogError("Enemy prefab or spawn location is not assigned!");
        }
    }

    public void OnEnemyDeath()
    {
        // Spawn additional enemies based on the rate of growth
        for (int i = 0; i < rateOfGrowth; i++)
        {
            SpawnEnemy();
        }
    }
}
