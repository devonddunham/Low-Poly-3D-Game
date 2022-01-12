using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    // public float turnSpeed;
    public Vector3 offset;

    void LateUpdate()
    {
        // dont do anything if we dont find any target
        if (!target)
            return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);

        // transform.RotateAround(target.transform.position, Vector3.up, Input.GetAxis("Mouse X") * turnSpeed);
    }
}
