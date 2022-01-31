using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlatformerGameOver : MonoBehaviour
{
    private PlatformerPlayerController player;
    private Distance distance;
    public float highscore = 0;

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
        PlayerPrefs.GetInt("platformer_highscore", roundedHighScore);
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
            if (distance.timer > highscore)
            {
                highscore = distance.timer;
                roundedScore = Mathf.RoundToInt(distance.timer);
                scoreTxt.text = "Score: " + roundedScore;
                roundedHighScore = Mathf.RoundToInt(highscore);
                highScoreTxt.text = "High Score: " + roundedHighScore;
            }
            Destroy(distance);
            PlayerPrefs.SetInt("platformer_highscore", roundedHighScore);
        }
    }
}
