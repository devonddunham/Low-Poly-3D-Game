using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    public int spawnItem;
    public int spawnPower;
    public GameObject[] obstacles;
    public GameObject[] powers;
    [HideInInspector] public GameObject currentOb;
    [HideInInspector] public GameObject currentPow;
    public Transform spawnPoint;
    public Transform powerSpawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentOb = obstacles[spawnItem];

        currentPow = powers[spawnPower];

    }

    public void SpawnObstacle()
    {
        spawnItem = Random.Range(0, obstacles.Length);
        Instantiate(currentOb, spawnPoint.transform.position, Quaternion.identity);
    }

    public void SpawnPowerUp()
    {

        Debug.Log("Power Ur Mom");
        spawnPower = Random.Range(0, powers.Length);
        Debug.Log(spawnPower);
        Instantiate(currentPow, powerSpawn.transform.position, currentPow.transform.rotation);
    }
}
