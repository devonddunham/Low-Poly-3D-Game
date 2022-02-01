using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlatformerGameOver : MonoBehaviour
{
    private PlatformerPlayerController player;
    private Distance distance;
    public static float highscore;

    [Header("UI Elements")]
    public GameObject duringGameScreen;
    public GameObject gameOverScreen;
    public Text highScoreTxt;
    public Text scoreTxt;
    int roundedHighScore;
    int roundedScore;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlatformerPlayerController>();
        distance = FindObjectOfType<Distance>();
        duringGameScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        highScoreTxt.text = "High Score: " + PlayerPrefs.GetFloat("platformer_highscore", 0).ToString("f2");
    }

    // Update is called once per frame
    void Update()
    {
        CheckLives();
        CheckScore();
    }

    public void CheckLives()
    {
        if (player.lives <= 0)
        {
            player.StopCamera();
            duringGameScreen.SetActive(false);
            gameOverScreen.SetActive(true);
            player.canMove = false;

            bool isRPressed = Input.GetKeyDown(KeyCode.R);
            if (isRPressed)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            duringGameScreen.SetActive(true);
            gameOverScreen.SetActive(false);
        }
    }

    public void CheckScore()
    {
        // buggy
        if (player.lives <= 0)
        {
            scoreTxt.text = "Score: " + distance.timer.ToString("f2");
            if (distance.timer > PlayerPrefs.GetFloat("platformer_highscore", 0))
            {
                highscore = distance.timer;
                highScoreTxt.text = "High Score: " + highscore.ToString("f2");
                PlayerPrefs.SetFloat("platformer_highscore", highscore);
            }
            distance.timerPlaying = false;
        }
    }
}
