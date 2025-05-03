using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    private Rigidbody2D rb;
    [SerializeField] private GameObject bulletPrefab; // Prefab for the bullet
    [SerializeField] private Transform bulletSpawnPoint; // Point where the bullet will be spawned

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle rotation to face the mouse
        RotateToMouse();
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            shooting();

        }
    }

    void FixedUpdate()
    {
        // Handle movement
        MovePlayer();
    }

    private void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(moveX, moveY) * moveSpeed;
        rb.velocity = move;
    }

    private void RotateToMouse()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Calculate the angle and rotate the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90f; // Adjust for the sprite's orientation
        rb.rotation = angle;
    }
    private void shooting(){
        // this function will instantiate the bullet object
        Debug.Log("BANG!");
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}
