using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{
    public Transform initPos;
    public GameObject[] buildings;
    PlatformerPlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlatformerPlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        float randomHeight = Random.Range(-10, 10);
        Transform playerPosition = new Vector3(player.transform.position.x, player.transform.position.y - +randomHeight, player.tranform.z);
        if (other.gameObject.tag == "Player")
        {
            GameObject randomBuildingSet = buildings[Random.Range(0, buildings.Length)];
            Instantiate(randomBuildingSet, initPos.transform.position, Quaternion.identity);
        }
    }
}
