using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    private SpawnPoints spawnPoints;

    public void SetSpawnPoints(SpawnPoints spawnPoints)
    {
        this.spawnPoints = spawnPoints;
    }

    private void OnDestroy()
    {
        if (spawnPoints != null)
        {
            spawnPoints.OnEnemyDeath(); // Notify the SpawnPoints script when this enemy is destroyed
        }

        Destroy(gameObject); // Destroy the enemy object
    }
}
