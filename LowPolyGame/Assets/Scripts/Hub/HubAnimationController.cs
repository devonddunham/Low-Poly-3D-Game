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
                // cams[0].SetActive(true);
                // cams[1].SetActive(false);
            }
            else
            {
                menuAnim.SetActive(false);
                isPlaying = false;
                // cams[0].SetActive(false);
                // cams[1].SetActive(true);
            }
        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            menuAnim.SetActive(false);
            isPlaying = false;
            // cams[0].SetActive(false);
            // cams[1].SetActive(true);
        }
    }
}
