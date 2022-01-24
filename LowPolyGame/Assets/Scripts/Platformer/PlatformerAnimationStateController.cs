using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformerAnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;
    PlatformerPlayerController player;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");

        player = FindObjectOfType<PlatformerPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Animation();
    }

    public void Animation()
    {
        // if no animator
        if (!animator)
            return;

        if (player.canMove)
        {
            bool walkingPressed = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d");
            bool isWalking = animator.GetBool(isWalkingHash);

            bool runningPressed = Input.GetKey("left shift");
            bool isRunning = animator.GetBool(isRunningHash);

            bool jumpingPressed = Input.GetKeyDown("space");
            bool isJumping = animator.GetBool(isJumpingHash);

            if (!isWalking && walkingPressed)
            {
                animator.SetBool(isWalkingHash, true); // start walk anim
            }
            else if (isWalking && !walkingPressed)
            {
                animator.SetBool(isWalkingHash, false); // stop walk anim
            }

            if (!isRunning && (walkingPressed && runningPressed))
            {
                animator.SetBool(isRunningHash, true); // start run anim
            }
            else if (isRunning && (!walkingPressed || !runningPressed))
            {
                animator.SetBool(isRunningHash, false); // stop run anim
            }

            if ((player.isGrounded) && !isJumping && jumpingPressed)
            {
                animator.SetBool(isJumpingHash, true);
            }
            else if ((player.isGrounded || !player.isGrounded) && (isJumping) && (!jumpingPressed))
            {
                animator.SetBool(isJumpingHash, false);
            }
        }
    }
}
