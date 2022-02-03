using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubAnimationController : MonoBehaviour
{
    public GameObject menuAnim;
    // public GameObject[] cams;

    // [HideInInspector]
    [HideInInspector] public bool isPlaying;
    Animator anim;


    void Start()
    {
        menuAnim.SetActive(true);
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
                menuAnim.SetActive(false);
                isPlaying = false;
            }
        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            menuAnim.SetActive(false);
            isPlaying = false;
        }
    }
}
