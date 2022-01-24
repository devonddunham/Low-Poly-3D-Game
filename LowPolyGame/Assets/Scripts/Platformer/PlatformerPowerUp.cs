using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPowerUp : MonoBehaviour
{
    private PlatformerPlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlatformerPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Extra Life")
            {
                player.lives++;
                player.livesText.text = "Lives: " + player.lives;
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Speed")
            {
                player.speed = player.speed + 1;
                Destroy(gameObject);
            }
        }

    }
}
