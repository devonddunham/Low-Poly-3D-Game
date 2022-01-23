using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerCameraController : MonoBehaviour
{
    public GameObject player;

    [Header("Min's & Max's")]
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Update is called once per frame
    void LateUpdate()
    {
        CameraMovement();
    }

    void CameraMovement()
    {
        if (!player)
            return;
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
