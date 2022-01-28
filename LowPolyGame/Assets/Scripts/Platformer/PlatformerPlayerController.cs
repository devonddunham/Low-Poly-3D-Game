using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlatformerPlayerController : MonoBehaviour
{
    [Header("Movement")]
    [Range(1, 10)] public float speed;
    [Range(1, 10)] public float jumpSpeed;
    float moveVelocity;


    // other
    GameObject player;
    [HideInInspector] public bool isGrounded = true;
    Rigidbody rb;
    [HideInInspector] public bool canMove = false;


    // movement
    [HideInInspector] public bool isMovingLeft;
    [HideInInspector] public bool isMovingRight;


    [Header("Lives")]
    public int lives = 3;
    public Text livesText;

    [Header("Respawn")]
    public Transform respawnPoint;

    [HideInInspector] public Distance distance;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player GFX");
        distance = FindObjectOfType<Distance>();
        livesText.text = "Lives: " + lives;
    }

    void Update()
    {
        if (canMove)
        {
            Jump();
            Movement();
        }

        if (lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Check if Grounded
        isGrounded = true;
    }


    public void Jump()
    {
        bool isJumping = Input.GetButtonDown("Jump");
        //Jumping
        if (isJumping && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            isGrounded = false;
        }
    }

    public void Movement()
    {
        moveVelocity = 0;

        isMovingLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        isMovingRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        //Left Right Movement
        if (isMovingLeft)
        {
            moveVelocity = -speed;
            transform.eulerAngles = new Vector3(0, -90, 0); // Flipped
            // transform.localScale = new Vector2(1f, 1f);
        }
        if (isMovingRight)
        {
            transform.eulerAngles = new Vector3(0, 90, 0); // Flipped
            moveVelocity = speed;
            // transform.localScale = new Vector2(-1f, 1f);
        }

        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
    }
}
