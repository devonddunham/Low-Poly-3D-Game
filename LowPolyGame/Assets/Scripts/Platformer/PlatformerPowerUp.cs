using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPowerUp : MonoBehaviour
{
    private PlatformerPlayerController player;
    private Distance distance;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlatformerPlayerController>();
        distance = FindObjectOfType<Distance>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log(gameObject.name + " Collided With " + other.name);
            if (gameObject.tag == "Extra Life")
            {
                player.lives++;
                player.livesText.text = "Lives: " + player.lives;
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Speed")
            {
                player.speed = player.speed + 1;
                distance.multiplier += 0.2f;
                Debug.Log("Player Speed: " + player.speed);
                Debug.Log("Multiplier: " + distance.multiplier);
                Destroy(gameObject);
            }
        }

    }
}
