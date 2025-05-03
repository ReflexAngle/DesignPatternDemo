using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour
{
    private float speed = 100f; // Speed of the bullet
    private float timeToDestroy = 2f; // Time before the bullet is destroyed

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
            // Destroy the bullet and the enemy
            Destroy(gameObject); // Destroy the bullet
            Destroy(collision.gameObject);
        }
        // will just destory the game object when it hits the wall 
        if (collision.CompareTag("Wall")){
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
