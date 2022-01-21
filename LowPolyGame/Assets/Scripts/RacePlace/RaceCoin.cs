using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCoin : MonoBehaviour
{
    public RaceCarMovement raceMove;
    public float additionalSpeed;
    void Start()
    {
        raceMove = FindObjectOfType<RaceCarMovement>();
        Destroy(gameObject, 20);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            raceMove.AddScore();
            raceMove.moveSpeed += additionalSpeed;
            Destroy(gameObject);
        }
    }
}
