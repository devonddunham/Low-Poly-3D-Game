using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceBarrier : MonoBehaviour
{
    public RaceCarMovement raceMove;
    void Start()
    {
        raceMove = FindObjectOfType<RaceCarMovement>();
        Destroy(gameObject, 20);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            raceMove.RemoveHealth();
            Destroy(gameObject);
        }
    }
}
