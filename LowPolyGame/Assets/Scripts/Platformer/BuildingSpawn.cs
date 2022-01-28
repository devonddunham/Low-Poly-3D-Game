using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{
    public Transform initPos;
    public GameObject[] buildings;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject randomBuildingSet = buildings[Random.Range(0, buildings.Length)];
            Instantiate(randomBuildingSet, initPos.transform.position, Quaternion.identity);
        }
    }
}
