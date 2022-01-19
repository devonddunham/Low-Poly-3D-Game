using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    public int spawnItem;

    public GameObject[] obstacles;
    public GameObject currentOb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentOb = obstacles[spawnItem];

        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnObstacle();
        }

    }

    void SpawnObstacle()
    {
        spawnItem = Random.Range(0, obstacles.Length);

    }
}
