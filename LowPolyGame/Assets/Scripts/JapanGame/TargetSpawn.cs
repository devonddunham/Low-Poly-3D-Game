using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{

    public int spawnItem;
    public int randTime;
    public GameObject[] targets;

    [HideInInspector] public GameObject currentOb;
    // Start is called before the first frame update
    void Start()
    {
        randTime = Random.Range(5, 15);
    }

    // Update is called once per frame
    void Update()
    {
        currentOb = targets[spawnItem];
    }

    public void SpawnTarget()
    {
        spawnItem = Random.Range(0, targets.Length);
        Instantiate(currentOb, transform.position, Quaternion.identity);
    }

    public IEnumerator SpawnCount()
    {
        Debug.Log("You");
        randTime = Random.Range(5, 15);
        yield return new WaitForSeconds(randTime);
        SpawnTarget();
    }
}
