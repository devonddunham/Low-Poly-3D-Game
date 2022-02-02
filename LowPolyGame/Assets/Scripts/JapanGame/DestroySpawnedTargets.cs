using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpawnedTargets : MonoBehaviour
{

    public bool canDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CanDestroy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            Debug.Log("nerd");
            if (canDestroy)
            {
                Debug.Log("Destroy");
                Destroy(other.gameObject);
            }
        }
    }

    public IEnumerator CanDestroy()
    {
        canDestroy = false;
        yield return new WaitForSeconds(.5f);
        canDestroy = true;
    }

}
