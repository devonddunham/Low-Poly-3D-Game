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
    public ShootingTarget shootingScript;
    public GameObject freezePanel;
    public GameObject timerText;

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
        shootingScript = FindObjectOfType<ShootingTarget>();
        fpsController = FindObjectOfType<FPSController>();
        projectileScript = FindObjectOfType<Projectile>();
        windRush.SetActive(false);
        gameOverHighScore.text = "High Score: " + PlayerPrefs.GetFloat("japan_highscore", 0).ToString();
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
        freezePanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        freeze = false;
        freezePanel.SetActive(false);
        fpsController.canMove = true;
        projectileScript.canThrow = true;
    }

    public void GameOver()
    {
        ScoreManager();

        timerText.SetActive(false);
        fpsController.canMove = false;
        scoreText.transform.parent.gameObject.SetActive(false);
        fpsController.UnLock();
        CrossHair.SetActive(false);
        projectileScript.canThrow = false;
        gameOverPanel.SetActive(true);


    }

    public void ScoreManager()
    {
        gameOverScore.text = "Score: " + score;
        if (score > PlayerPrefs.GetFloat("japan_highscore", 0))
        {
            highscore = score;
            gameOverHighScore.text = "High Score: " + highscore.ToString();
            PlayerPrefs.SetFloat("japan_highscore", highscore);
        }
    }
}
