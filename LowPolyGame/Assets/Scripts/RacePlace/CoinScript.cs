using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public RaceCarMovement raceMove;
    public float additionalSpeed;
    void Start()
    {
        raceMove = FindObjectOfType<RaceCarMovement>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            raceMove.moveSpeed += additionalSpeed;
            Destroy(gameObject);
        }
    }
}
