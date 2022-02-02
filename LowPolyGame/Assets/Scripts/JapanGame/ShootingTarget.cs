using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTarget : MonoBehaviour
{

    GameObject player;
    public float speed = 1.0f;
    public GameObject bullet;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootBullet());
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsPlayer();
    }

    public void RotateTowardsPlayer()
    {
        Vector3 playerDirection = player.transform.position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 _Dir = Vector3.RotateTowards(transform.forward, playerDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, playerDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(playerDirection);
    }

    public IEnumerator ShootBullet()
    {

        yield return new WaitForSeconds(2f);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        StartCoroutine(ShootBullet());
    }

}
