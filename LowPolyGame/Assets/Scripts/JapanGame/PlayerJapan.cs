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
    ShootingTarget shootingScript;
    public GameObject freezePanel;

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
        PlayerPrefs.SetInt("japan_highscore", highscore);
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
        shootingScript.canShoot = false;
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

        PlayerPrefs.SetInt("japan_highscore", highscore);

    }
}
