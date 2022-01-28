using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlatformerGameOver : MonoBehaviour
{
    private PlatformerPlayerController player;
    private Distance distance;

    public static int score;
    public static float highscore;

    [Header("UI Elements")]
    public GameObject duringGameScreen;
    public GameObject gameOverScreen;
    public Text highScoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlatformerPlayerController>();
        distance = FindObjectOfType<Distance>();
        duringGameScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckLives();
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
            player.canMove = true;
        }
    }

    public void CheckScore()
    {
        if (distance.timer > highscore)
        {
            highscore = distance.timer;
            highScoreTxt.text = "" + score;
        }

        // int roundedHighScore = Mathf.Round(highscore);
        // PlayerPrefs.SetInt("highscore", roundedHighScore);
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public static void Reset()
    {
        score = 0;
    }
}
