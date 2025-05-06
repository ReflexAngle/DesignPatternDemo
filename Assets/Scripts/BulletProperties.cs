using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour
{
    private float speed = 100f; // Speed of the bullet
    private float timeToDestroy = 2f; // Time before the bullet is destroyed
    private int damage = 10;
    private SpawnPoints spawnPoints; // Reference to the SpawnPoints script
    private void Start()
{
    if (spawnPoints == null)
    {
        spawnPoints = FindObjectOfType<SpawnPoints>(); // Find the SpawnPoints script in the scene
        if (spawnPoints == null)
        {
            Debug.LogError("No SpawnPoints object found in the scene!");
        }
    }
}
    void Update()
    {
        MoveBullet();
        TimeToDestory(); // Call the function to destroy the bullet after a certain time
    }
    private void MoveBullet(){
        transform.Translate (Vector2.up * speed * Time.deltaTime);

    }
    // destroys the bullet after some time to keep the game clean
    private void TimeToDestory(){
        Destroy(gameObject, timeToDestroy); // Destroy the bullet after a certain time

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the bullet
            Debug.Log("Bullet hit enemy"); // Log a message to the console
        }
        // will just destory the game object when it hits the wall 
        else if (collision.CompareTag("Wall")){
            Destroy(gameObject); // Destroy the bullet
        }else if (collision.CompareTag("Spawner")){
            spawnPoints.sqawnPointHealth -= damage; // Reduce the spawn point's health by the bullet's damage
            Debug.Log("Bullet hit spawn point"); // Log a message to the console
            if (spawnPoints.sqawnPointHealth <= 0)
            {
                spawnPoints.handleDestroy(); // Call the handleDestroy method to destroy the spawn point
            }
        }
    }
}
