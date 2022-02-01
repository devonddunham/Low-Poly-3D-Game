using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private PlatformerPlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlatformerPlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!player)
            return;
        if (other.gameObject.tag == "Player")
        {

            player.lives--;
            player.livesText.text = "Lives: " + player.lives;
            // subtracting distance when you die to something
            if (player.distance.timer <= 5)
            {
                player.distance.timer = 0;
            }
            else
            {
                player.distance.timer = player.distance.timer - 5f;
            }
            player.transform.position = player.respawnPoint.transform.position;
            player.ResetCamera();
        }
    }
}
