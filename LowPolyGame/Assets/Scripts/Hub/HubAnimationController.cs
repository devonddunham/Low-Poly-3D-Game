using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubAnimationController : MonoBehaviour
{
    public static HubAnimationController instance;
    public GameObject menuAnim;
    public GameObject playerCam;

    // [HideInInspector]
    [HideInInspector] public bool isPlaying;
    [HideInInspector] public Animator anim;


    void Start()
    {
        instance = this;
        menuAnim.SetActive(true);
        playerCam.SetActive(false);
        isPlaying = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!menuAnim.activeInHierarchy)
            {
                menuAnim.SetActive(true);
                isPlaying = true;
            }
            else
            {
                playerCam.SetActive(true);
                menuAnim.SetActive(false);
                isPlaying = false;
            }
        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            playerCam.SetActive(true);
            menuAnim.SetActive(false);
            isPlaying = false;
        }
    }
}
