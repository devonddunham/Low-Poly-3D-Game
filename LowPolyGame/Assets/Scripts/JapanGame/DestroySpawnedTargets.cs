using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpawnedTargets : MonoBehaviour
{

    public bool canDestroy = false;
    public bool destroyObj = false;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(CanDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyObj == true)
        {
            Debug.Log("Aidan is cool");
            Destroy(gameObject, 3f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {

            if (canDestroy)
            {
                other.GetComponentInParent<DestroySpawnedTargets>().destroyObj = true;
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
