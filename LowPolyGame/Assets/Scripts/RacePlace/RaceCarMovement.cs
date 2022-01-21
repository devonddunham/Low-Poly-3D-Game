using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RaceCarMovement : MonoBehaviour
{

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
    public void Start()
    {
        healthText.text = "Lives: " + health;
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

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

        if (health <= 0)
        {
            gameOverPanel.SetActive(true);
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
}
