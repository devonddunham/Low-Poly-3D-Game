using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{

    public int spawnItem;
    public int randTime;
    public GameObject[] targets;


    [HideInInspector] public GameObject currentOb;

    [SerializeField]
    private bool canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        spawnItem = Random.Range(0, targets.Length);
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
        if (other.gameObject.tag == "Target")
        {
            canSpawn = false;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            canSpawn = true;
        }
    }


}
