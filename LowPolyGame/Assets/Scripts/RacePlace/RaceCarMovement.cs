using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RaceCarMovement : MonoBehaviour
{

    public static int highscore;


    public float moveSpeed = 5f;
    public float turnSpeed = 10f;
    public Animator animController;
    public int carPosition = 0;

    public GameObject car;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;


    public int score;
    public Text scoreText;

    public int health = 3;
    public Text healthText;
    public bool canAnim = false;
    public GameObject gameOverPanel;

    public Text gameOverScore;
    public Text gameOverHighScore;

    public bool canMove = true;
    public bool canShoot = false;

    public GameObject missile;
    public int amountMissles;
    public Transform firePoint;
    public GameObject launcher;
    public Text misText;

    public void Start()
    {
        score = 0;
        misText.transform.parent.gameObject.SetActive(false);
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        healthText.text = "Lives: " + health;
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        GameOver();
        Movement();


    }

    public void AddScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }
    public void RemoveHealth()
    {
        health -= 1;
        healthText.text = "Lives: " + health;
    }

    public void GameOver()
    {
        if (health <= 0)
        {
            ScoreManager();
            canMove = false;
            scoreText.transform.parent.gameObject.SetActive(false);
            healthText.transform.parent.gameObject.SetActive(false);
            gameOverPanel.SetActive(true);
        }

    }

    public void Movement()
    {

        if (!canMove)
            return;

        Shooting();
        if (moveSpeed > 500)
        {
            moveSpeed = 500;
        }

        if (health > 10)
        {
            health = 10;
            score += 100;
            scoreText.text = "Score: " + score;
            healthText.text = "Lives: " + health;
        }


        scoreText.transform.parent.gameObject.SetActive(true);
        healthText.transform.parent.gameObject.SetActive(true);

        if (carPosition == 2)
        {
            carPosition -= 1;
        }
        if (carPosition == -2)
        {
            carPosition += 1;
        }



        if (carPosition == -1)
        {
            car.transform.position = Vector3.MoveTowards(car.transform.position, pos1.transform.position, turnSpeed * Time.deltaTime);
            if (car.transform.position == pos1.transform.position)
            {



                animController.SetBool("canTurnLeft", false);
            }

        }




        if (carPosition == 0)
        {
            car.transform.position = Vector3.MoveTowards(car.transform.position, pos2.transform.position, turnSpeed * Time.deltaTime);
            // if (car.transform.position == pos2.transform.position)
            // {
            animController.SetBool("canTurnLeft", false);
            animController.SetBool("canTurnRight", false);


            if (Input.GetKeyDown(KeyCode.A))
            {

                animController.Play("TurnLeft");
                animController.SetBool("canTurnLeft", true);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {

                animController.Play("TurnRight");
                animController.SetBool("canTurnRight", true);
            }
            //   }

        }


        if (carPosition == 1)
        {
            car.transform.position = Vector3.MoveTowards(car.transform.position, pos3.transform.position, turnSpeed * Time.deltaTime);
            if (car.transform.position == pos3.transform.position)
            {


                animController.SetBool("canTurnRight", false);


            }

        }



        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (Input.GetKeyDown(KeyCode.A))
        {
            canAnim = true;
            carPosition -= 1;
            animController.Play("TurnLeft");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            canAnim = true;
            carPosition += 1;
            animController.Play("TurnRight");
        }
    }

    public void ScoreManager()
    {
        if (score > highscore)
            highscore = score;

        gameOverScore.text = "Score: " + score;
        gameOverHighScore.text = "High Score: " + highscore;

        PlayerPrefs.SetInt("highscore", highscore);
    }

    public void Shooting()
    {
        if (amountMissles <= 0)
        {
            canShoot = false;
            misText.transform.parent.gameObject.SetActive(false);
            launcher.SetActive(false);
        }

        if (amountMissles > 10)
        {
            amountMissles = 10;
            score += 100;
        }

        if (canShoot == true)
        {
            misText.transform.parent.gameObject.SetActive(true);
            misText.text = "Missile " + amountMissles;
            if (amountMissles > 0)
            {
                launcher.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    amountMissles -= 1;
                    Instantiate(missile, firePoint.transform.position, missile.transform.rotation);
                }
            }

        }
    }
}
