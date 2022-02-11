using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerJapan : MonoBehaviour
{
    public static int highscore;
    public bool freeze = false;
    public GameObject windRush;
    public GameObject handShuriken;
    public GameObject CrossHair;
    public float windWaitTime;
    Projectile projectileScript;

    public GameObject gameOverPanel;
    FPSController fpsController;
    Projectile projectile;
    public int score;

    public Text scoreText;

    public Text gameOverScore;
    public Text gameOverHighScore;

    // Start is called before the first frame update
    void Start()
    {
        fpsController = FindObjectOfType<FPSController>();
        projectileScript = FindObjectOfType<Projectile>();
        windRush.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WindRush();

        if (freeze == true)
        {
            StartCoroutine(Freeze());
        }
    }

    public void WindRush()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(WindSoundTimer());
        }
    }

    public void ScoreUp()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }

    public IEnumerator HandShuriken()
    {
        projectileScript.canThrow = false;
        handShuriken.gameObject.SetActive(false);
        yield return new WaitForSeconds(windWaitTime);
        projectileScript.canThrow = true;
        handShuriken.gameObject.SetActive(true);

    }

    public IEnumerator WindSoundTimer()
    {
        windRush.gameObject.SetActive(true);
        yield return new WaitForSeconds(windWaitTime);
        windRush.gameObject.SetActive(false);

    }

    public IEnumerator Freeze()
    {
        projectileScript.canThrow = false;
        fpsController.canMove = false;
        yield return new WaitForSeconds(1f);
        freeze = false;
        fpsController.canMove = true;
        projectileScript.canThrow = true;
    }

    public void GameOver()
    {
        ScoreManager();
        fpsController.canMove = false;
        scoreText.transform.parent.gameObject.SetActive(false);
        fpsController.UnLock();
        CrossHair.SetActive(false);
        projectileScript.canThrow = false;
        gameOverPanel.SetActive(true);
    }

    public void ScoreManager()
    {
        if (score > highscore)
            highscore = score;

        gameOverScore.text = "Score: " + score;
        gameOverHighScore.text = "High Score: " + highscore;

        PlayerPrefs.SetInt("highscore", highscore);
    }
}
