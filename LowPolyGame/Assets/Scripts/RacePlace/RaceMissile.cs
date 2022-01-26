using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceMissile : MonoBehaviour
{

   
    RaceCarMovement raceMove;
    // Start is called before the first frame update
    void Start()
    {
        raceMove = FindObjectOfType<RaceCarMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * raceMove.moveSpeed * 2, Space.World);
    }

    
}
