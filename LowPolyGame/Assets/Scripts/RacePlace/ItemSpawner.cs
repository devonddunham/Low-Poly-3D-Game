using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    public int spawnItem;

    public GameObject[] obstacles;
    [HideInInspector] public GameObject currentOb;
    public Transform spawnPoint;
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

    public void SpawnObstacle()
    {
        spawnItem = Random.Range(0, obstacles.Length);
        Instantiate(currentOb, spawnPoint.transform.position, Quaternion.identity);
    }
}
