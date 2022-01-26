using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawnerRace : MonoBehaviour
{
    ItemSpawner itemSpawner;
    public Transform spawnTrigger;

    void Start()
    {
        itemSpawner = FindObjectOfType<ItemSpawner>();

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            itemSpawner.SpawnPowerUp();
            transform.position = spawnTrigger.transform.position;
        }
    }
}
