using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyTemplate enemyAI;

    void Start()
    {
        // Create an instance of the specific AI implementation
        enemyAI = new MeleeAI(this.gameObject);
    }

    void Update()
    {
        // Simply call the Template Method each frame!
        // The base class ensures the steps run in order, using the
        // implementations from SimpleMeleeAI.
        enemyAI.UpdateBehavior(Time.deltaTime);
    }
}
