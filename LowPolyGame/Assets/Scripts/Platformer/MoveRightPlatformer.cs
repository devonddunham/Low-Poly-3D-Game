using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightPlatformer : MonoBehaviour
{
    public int movingSpeed;
    PlatformerCameraController cameraController;


    void Start()
    {
        cameraController = FindObjectOfType<PlatformerCameraController>();
    }
    void Update()
    {
        if (cameraController.isCameraMoving)
        {
            transform.position += Vector3.right * Time.deltaTime * movingSpeed;
        }
    }
}
