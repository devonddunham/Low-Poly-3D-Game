using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerCameraController : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void LateUpdate()
    {
        CameraMovement();
    }

    void CameraMovement()
    {
        if (!player)
            return;
        Vector3 offset = transform.position - player.transform.position;
        bool changeInX = false;
        bool changeInY = false;
        Vector3 newCameraPosition = transform.position;
        if (offset.x > 3)
        {
            changeInX = true;
            newCameraPosition.x = (player.transform.position.x + offset.x) - (offset.x - 3);
        }
        else if (offset.x < -3)
        {
            changeInX = true;
            newCameraPosition.x = (player.transform.position.x + offset.x) - (offset.x + 3);
        }
        if (offset.y > 2)
        {
            changeInY = true;
            newCameraPosition.y = (player.transform.position.y + offset.y) - (offset.y - 2);
        }
        else if (offset.y < -2)
        {
            changeInY = true;
            newCameraPosition.y = (player.transform.position.y + offset.y) - (offset.y + 2);
        }
        if (!changeInX)
        {
            newCameraPosition.x = transform.position.x;
        }
        if (!changeInY)
        {
            newCameraPosition.y = transform.position.y;
        }
        transform.position = newCameraPosition;
    }
}
