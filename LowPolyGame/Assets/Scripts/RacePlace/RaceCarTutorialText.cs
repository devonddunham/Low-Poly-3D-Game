using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCarTutorialText : MonoBehaviour
{
    private RaceCarMovement raceCar;
    private GameObject tutorialText;
    private GameObject stats;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        raceCar = FindObjectOfType<RaceCarMovement>();
        anim = GetComponent<Animator>();
        tutorialText = GameObject.Find("Tutorial Text Slideshow");
        stats = GameObject.Find("Stats");

        stats.SetActive(false);
        raceCar.canMove = false;
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
            tutorialText.SetActive(false);
            stats.SetActive(true);
        }
    }

    public void SkipTutorialText()
    {
        tutorialText.SetActive(false);
        stats.SetActive(true);
        RaceCarMovement.instance.canMove = true;
    }
}
