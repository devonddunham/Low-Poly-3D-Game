using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRace : MonoBehaviour
{
    RaceCarMovement raceCarMovement;
    void Start()
    {
        raceCarMovement = FindObjectOfType<RaceCarMovement>();
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            raceCarMovement.health++;
            raceCarMovement.healthText.text = "Lives: " + raceCarMovement.health;
            Destroy(gameObject);
        }

        else if (other.gameObject.tag == "Death" || other.gameObject.tag == "Coin")
        {
            Destroy(gameObject);
        }
    }
}
