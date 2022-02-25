using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JapanTutorialText : MonoBehaviour
{
    private GameObject tutorialText;
    private GameObject stats;
    FPSController player;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        tutorialText = GameObject.Find("Tutorial Text Slideshow");
        stats = GameObject.Find("Score + Timer");
        player = FindObjectOfType<FPSController>();
        anim = GetComponent<Animator>();

        player.UnLock();
        stats.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TutorialAnimation();
    }

    void TutorialAnimation()
    {
        if (this.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            player.canMove = true;
            tutorialText.SetActive(false);
            stats.SetActive(true);
            player.Lock();
        }
    }

    public void SkipTutorialText()
    {
        tutorialText.SetActive(false);
        stats.SetActive(true);
        player.canMove = true;
        player.Lock();
    }
}
