using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCarTutorialText : MonoBehaviour
{
    private GameObject tutorialText;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        tutorialText = GameObject.Find("Tutorial Text Slideshow");
        anim = GetComponent<Animator>();
        RaceCarMovement.instance.canMove = false;
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
            RaceCarMovement.instance.canMove = true;
        }
    }

    public void SkipTutorialText()
    {
        tutorialText.SetActive(false);
        RaceCarMovement.instance.canMove = true;
    }
}
