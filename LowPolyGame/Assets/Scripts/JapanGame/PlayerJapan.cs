using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJapan : MonoBehaviour
{
    public bool canShoot = true;
    public Rigidbody shuriken;
    public Transform firePoint;
    public int shurikenSpeed;

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
                Rigidbody shurikenClone = (Rigidbody)Instantiate(shuriken, firePoint.transform.position, transform.rotation);

                shuriken.velocity = transform.forward * shurikenSpeed;
            }


        }
    }
}
