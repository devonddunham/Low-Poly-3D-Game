using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{

    [SerializeField]
    Transform[] wayPoints;
    int currentWayPoint = 0;
    public GameObject position;
    Rigidbody rb;
    [SerializeField]
    float moveSpeed = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Instantiate(position, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Vector3.Distance(transform.position, wayPoints[currentWayPoint].position) < .25f)
        {
            currentWayPoint += 1;
            currentWayPoint = currentWayPoint % wayPoints.Length;
        }
        Vector3 _dir = -(wayPoints[currentWayPoint].position - transform.position).normalized;
        rb.MovePosition(transform.position + _dir * moveSpeed * Time.deltaTime);
    }
}
