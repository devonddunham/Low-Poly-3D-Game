using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    private GameObject tutorialText;
    PlatformerPlayerController player;
    Animator anim;
    PlatformerCameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        tutorialText = GameObject.Find("Tutorial Text Slideshow");
        player = FindObjectOfType<PlatformerPlayerController>();
        cameraController = FindObjectOfType<PlatformerCameraController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TutorialAnimation();
    }

    void TutorialAnimation()
    {
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     cameraController.isCameraMoving = true;
        //     if (tutorialText.activeInHierarchy)
        //     {

        //     }
        //     else if (!tutorialText.activeInHierarchy)
        //     {
        //         tutorialText.SetActive(true);
        //         player.canMove = false;
        //     }
        // }

        if (this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            player.canMove = true;
            cameraController.isCameraMoving = true;
        }
    }

    public void SkipTutorialText()
    {
        cameraController.isCameraMoving = true;
        tutorialText.SetActive(false);
        player.canMove = true;
    }
}
