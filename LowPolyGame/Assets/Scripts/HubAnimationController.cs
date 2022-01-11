using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubAnimationController : MonoBehaviour
{
    private GameObject menuAnim;
    [HideInInspector] public bool isPlaying;

    void Start()
    {
        menuAnim = GameObject.Find("MenuAnimation");
        menuAnim.SetActive(true);
    }

    void Update()
    {
        bool isPPressed = Input.GetKey(KeyCode.P);

        if (isPPressed)
        {
            if (!menuAnim.activeInHierarchy)
            {
                menuAnim.SetActive(true);
                isPlaying = true;
            }
            else if (menuAnim.activeInHierarchy)
            {
                menuAnim.SetActive(false);
            }
        }
    }
}
