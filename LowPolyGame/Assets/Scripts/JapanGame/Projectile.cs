using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchSpeed = 300f;
    public float heightSpeed = 50f;
    public Transform firePoint;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Vector3 rot = transform.rotation.eulerAngles;
            //  rot = new Vector3(rot.x, rot.y, rot.z);
            // Quaternion orientation = Quaternion.Euler(rot);
            GameObject shuriken = Instantiate(projectile, firePoint.transform.position, rotation: transform.rotation);
            shuriken.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, heightSpeed, launchSpeed));
        }
    }
}
