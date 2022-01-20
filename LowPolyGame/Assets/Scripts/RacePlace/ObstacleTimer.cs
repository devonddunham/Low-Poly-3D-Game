using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTimer : MonoBehaviour
{
    public ItemSpawner itemSpawner;
    public Transform spawnTrigger;

    void Start()
    {
        itemSpawner = FindObjectOfType<ItemSpawner>();

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            itemSpawner.SpawnObstacle();
            transform.position = spawnTrigger.transform.position;
        }
    }


}
