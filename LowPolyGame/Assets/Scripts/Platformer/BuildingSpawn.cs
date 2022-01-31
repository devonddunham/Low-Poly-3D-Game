using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{
    public Transform instantiatePos;
    public GameObject[] buildings;
    PlatformerPlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlatformerPlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        float randomHeight = Random.Range(-0.1f, 0.1f);
        Vector3 playerPos = player.transform.position;
        Vector3 spawnPos = playerPos * randomHeight;

        if (other.gameObject.tag == "Player")
        {
            GameObject randomBuildingSet = buildings[Random.Range(0, buildings.Length)];
            Instantiate(randomBuildingSet, instantiatePos.transform.position + spawnPos, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
