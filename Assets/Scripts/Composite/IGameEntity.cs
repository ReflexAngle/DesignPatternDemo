using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEntity 
{
    void Spawn(Vector3 position);
    void Attack();
    void UpadteEnemy();
    void TakeDamage(int amount);
}
