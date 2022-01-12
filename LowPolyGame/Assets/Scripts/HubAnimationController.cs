using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubAnimationController : MonoBehaviour
{
    public GameObject menuAnim;

    // [HideInInspector]
    [HideInInspector] public bool isPlaying;


    void Start()
    {
        // menuAnim = GameObject.Find("MenuAnimation");
        menuAnim.SetActive(true);
        isPlaying = true;
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
    }
}
