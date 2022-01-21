using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformerPlayerController : MonoBehaviour
{
    //Movement
    public float speed;
    public float jumpSpeed;
    float moveVelocity;
    [SerializeField] bool isGrounded = true;
    Rigidbody rb;

    public bool isMovingLeft;
    public bool isMovingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jump();
        Movement();
    }
    //Check if Grounded
    void OnTriggerEnter()
    {
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
