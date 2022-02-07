using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{

    public int spawnItem;
    public int randTime;
    public GameObject[] targets;


    [HideInInspector] public GameObject currentOb;

    public bool canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        StartCoroutine(SpawnCount());
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
        Instantiate(currentOb, transform.position, transform.rotation);
    }

    public IEnumerator SpawnCount()
    {




        randTime = Random.Range(5, 15);
        yield return new WaitForSeconds(randTime);
        if (canSpawn)
        {
            SpawnTarget();
        }

        StartCoroutine(SpawnCount());

    }

    public void OnTriggerEnter(Collider other)
    {
        canSpawn = false;
    }
    public void OnTriggerExit(Collider other)
    {
        canSpawn = true;
    }


}
