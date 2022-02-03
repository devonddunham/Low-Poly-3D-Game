using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchSpeed = 300f;
    public float heightSpeed = 50f;
    public Transform firePoint;
    public bool canThrow = true;
    PlayerJapan playerScript;


    public void Start()
    {
        playerScript = FindObjectOfType<PlayerJapan>();
    }

    void Update()
    {
        if (canThrow)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // Vector3 rot = transform.rotation.eulerAngles;
                //  rot = new Vector3(rot.x, rot.y, rot.z);
                // Quaternion orientation = Quaternion.Euler(rot);
                StartCoroutine(playerScript.HandShuriken());
                GameObject shuriken = Instantiate(projectile, firePoint.position, rotation: transform.rotation);
                shuriken.GetComponentInChildren<Rigidbody>().AddRelativeForce(new Vector3(0, heightSpeed, launchSpeed));
            }
        }
    }
}
