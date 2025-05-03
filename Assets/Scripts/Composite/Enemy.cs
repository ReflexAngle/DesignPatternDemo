using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : IGameEntity
{
    public void Attack()
    {
        Debug.Log("Enemy Attacking!");
    }

    public void Spawn(Vector3 position)
    {
        Debug.Log("Enemy Spawned at " + position);
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Enemy took " + amount + " damage!");
    }

    public void UpadteEnemy()
    {
        Debug.Log("Enemy Updated!");
    }
}
