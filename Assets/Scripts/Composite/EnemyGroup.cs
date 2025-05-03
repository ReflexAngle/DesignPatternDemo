using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : IGameEntity
{
    private List<IGameEntity> _enemies = new List<IGameEntity>();

    public void Add(IGameEntity enemy)
    {
        _enemies.Add(enemy);
    }

    public void Remove(IGameEntity enemy)
    {
        _enemies.Remove(enemy);
    }

    public void Attack()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Attack();
        }
    }

    public void Spawn(Vector3 position)
    {
        foreach (var enemy in _enemies)
        {
            enemy.Spawn(position);
        }
    }

    public void TakeDamage(int amount)
    {
        foreach (var enemy in _enemies)
        {
            enemy.TakeDamage(amount);
        }
    }

    public void UpadteEnemy()
    {
        foreach (var enemy in _enemies)
        {
            enemy.UpadteEnemy();
        }
    }
}

