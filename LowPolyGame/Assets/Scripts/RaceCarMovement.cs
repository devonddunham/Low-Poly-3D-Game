using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCarMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Animator animController;

    public void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
    }
}
