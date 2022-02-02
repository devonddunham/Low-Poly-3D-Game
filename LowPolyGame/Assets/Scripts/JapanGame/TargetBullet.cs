using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBullet : MonoBehaviour
{

    GameObject player;
    private float rotateSpeed = 1000f;
    public int moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {


        Vector3 playerDirection = player.transform.position - transform.position;
        float singleStep = rotateSpeed * Time.deltaTime;
        Vector3 _Dir = Vector3.RotateTowards(transform.forward, playerDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, playerDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(playerDirection);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
    }
}
