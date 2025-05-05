using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

// makes sure that the player controller has a rigidbody2d component attached to it
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerRefactored : MonoBehaviour
{
    public float moveSpeed = 8f; // Speed of the player movement
    [SerializeField] private GameObject bulletPrefab; // Prefab for the bullet
    [SerializeField] private Transform bulletSpawnPoint; // Point where the bullet will be spawned
    private Vector2 currMoveInput = Vector2.zero;
    private Rigidbody2D rb; // Reference to the Rigidbody2D component   
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyMovement(); // Call the ApplyMovement method to move the player
    }
    public void Move(Vector2 direction)
    {

        currMoveInput = direction.normalized; // Update the current move input with the new direction
    }
    private void ApplyMovement()
    {
        // Calculate the new position based on the current input and move speed
        Vector2 movement = currMoveInput * moveSpeed * Time.fixedDeltaTime;
        Vector2 newPosition = rb.position + movement;
        rb.MovePosition(newPosition); // Move the Rigidbody2D to the new position
    }
    public void Rotate(Vector2 direction){
        if (direction == Vector2.zero || rb == null) return; // Avoid rotation if direction is zero

        // Calculate the angle and rotate the player Rigidbody
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90f; // Adjust based on your sprite's default orientation (e.g., if sprite faces 'up')
        rb.rotation = angle;
    }
    public void Shoot(){
        Debug.Log("BANG!"); 
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // Instantiate the bullet prefab at the spawn point
    }

}
