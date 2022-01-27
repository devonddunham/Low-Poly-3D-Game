using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePower : MonoBehaviour
{
    RaceCarMovement raceMove;



    public void Start()
    {
        raceMove = FindObjectOfType<RaceCarMovement>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("yo");
            raceMove.canShoot = true;
            raceMove.amountMissles += 3;
            Destroy(gameObject);
        }

        else if (other.gameObject.tag == "Death" || other.gameObject.tag == "Coin")
        {
            Destroy(gameObject);
        }
    }

}