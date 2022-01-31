using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{

    public int spawnItem;
    public int randTime;
    public GameObject[] targets;
    public Transform[] spawnPos;
    public int spawnInt;
    public Transform currentPos;
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
        currentPos = spawnPos[spawnInt];
    }

    public void SpawnTarget()
    {

        spawnInt = Random.Range(0, spawnPos.Length);
        spawnItem = Random.Range(0, targets.Length);
        Instantiate(currentOb, currentPos.position, currentPos.rotation);
    }

    public IEnumerator SpawnCount()
    {
        Debug.Log("You");
        randTime = Random.Range(5, 15);
        yield return new WaitForSeconds(randTime);
        SpawnTarget();
    }
}
