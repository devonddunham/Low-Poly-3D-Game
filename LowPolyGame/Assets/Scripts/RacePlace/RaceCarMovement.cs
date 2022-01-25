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
    public void Start()
    {
        score = 0;
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ExtraLife")
        {
            Debug.Log("UROMO");
            health++;
            healthText.text = "Lives: " + health;
        }
    }
}
