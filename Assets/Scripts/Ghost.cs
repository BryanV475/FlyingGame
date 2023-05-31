using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Ghost : MonoBehaviour
{
    public int health;

    private Rigidbody2D rb;

    private Camera cam;
    private float screenHeight;
    private float screenWidth;

    private float playerHeight;
    private float playerWidth;

    private Vector3 movementDirection;
    private float movementSpeed;

    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        health = 5;

        // Movement speed
        movementSpeed = 2.5f;

        // Control the bounds of the game using the maera
        cam = Camera.main;
        screenHeight = 2f * cam.orthographicSize;
        screenWidth = screenHeight * cam.aspect;
        playerHeight = 25f / 40f;
        playerWidth = 35f / 40f;

        // Deactivate gravity
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        // Implement Game Over
        if (health <= 0)
        {
            gameManager.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 

        // Check if Player Hits an Obstacle
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
        }
    }

    private void PlayerMovement()
    {
        // Get current player position
        Vector3 position = transform.position;

        // Reset movement direction
        movementDirection = Vector3.zero;

        // Detect movement input
        if (Input.GetKey(KeyCode.W))
        {
            movementDirection += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementDirection += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementDirection += Vector3.right;
        }

        // Calculate the movement offset based on time and speed
        Vector3 movementOffset = movementSpeed * Time.deltaTime * movementDirection;

        // Update player position
        position += movementOffset;

        // Apply updated position to the player
        transform.position = CheckBounds(position);
    }

    private Vector3 CheckBounds(Vector3 position)
    {
        // Calculate the half-size of the player sprite
        float halfPlayerHeight = playerHeight / 2f;
        float halfPlayerWidth = playerWidth / 2f;

        // Calculate the screen boundaries considering the player sprite size
        float screenBoundaryTop = screenHeight / 2f - halfPlayerHeight;
        float screenBoundaryBottom = -screenHeight / 2f + halfPlayerHeight;
        float screenBoundaryRight = screenWidth / 2f - halfPlayerWidth;
        float screenBoundaryLeft = -screenWidth / 2f + halfPlayerWidth;

        // Limit position within screen borders
        position.x = Mathf.Clamp(position.x, screenBoundaryLeft, screenBoundaryRight);
        position.y = Mathf.Clamp(position.y, screenBoundaryBottom, screenBoundaryTop);

        // Return the position
        return position;
    }

}
