using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJapan : MonoBehaviour
{
    public bool canShoot = true;
    public GameObject shuriken;
    public Transform firePoint;
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Throw();
    }

    public void Throw()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canShoot)
            {
                Debug.Log("Shoot");
                Instantiate(shuriken, firePoint.transform.position, camera.transform.rotation);
            }

            
        }
    }
}
