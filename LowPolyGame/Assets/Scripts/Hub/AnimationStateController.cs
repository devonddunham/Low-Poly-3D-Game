using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    public static AnimationStateController instance;
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isDancingHash;
    HubAnimationController hubAnimationController;

    public bool runningPressed;
    public bool walkingPressed;
    public bool isWalking;
    public bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isDancingHash = Animator.StringToHash("isDancing");

        hubAnimationController = FindObjectOfType<HubAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        Animation();
    }

    public void Animation()
    {
        // if hub animation is playing then dont allow the player to animate
        if (hubAnimationController.isPlaying)
            return;

        walkingPressed = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d");
        isWalking = animator.GetBool(isWalkingHash);

        runningPressed = Input.GetKey("left shift");
        isRunning = animator.GetBool(isRunningHash);

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

        if (Input.GetKey("t"))
        {
            animator.SetBool(isDancingHash, true); // start dance anim
        }
        else
        {
            animator.SetBool(isDancingHash, false); // stop dance anim
        }
    }
}
