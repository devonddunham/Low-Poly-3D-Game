using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("--- GAMEOBJECTS ---")]
    public GameObject player;
    public GameObject cameraCenter;

    [Header("--- FLOATS ---")]
    public float xOffset;
    public float yOffset;
    public float zOffset;
    public float sensitivity;
    public float scrollSensitivity;
    public float scrollDamping;
    public float zoomMin = 3.5f;
    public float zoomMax = 15f;
    public float zoomDefault = 10f;
    public float zoomDistance;
    public float collisionSensitivity = 4.5f;

    [Header("--- CAMERA ---")]
    public Camera cam;

    private RaycastHit camHit;
    private Vector3 camDist;

    void Start()
    {
        camDist = cam.transform.localPosition;
        zoomDistance = zoomDefault;
        camDist.z = zoomDistance;

        Cursor.visible = false;
    }

    void Update()
    {
        FollowAndRotate();
        Zooming();
        AntiCameraClipping();
    }

    void FollowAndRotate()
    {

        var xCamPos = player.transform.position.x + xOffset;
        var yCamPos = player.transform.position.y + yOffset;
        var zCamPos = player.transform.position.z + zOffset;
        cameraCenter.transform.position = new Vector3(xCamPos, yCamPos, zCamPos);

        var mouseY = Input.GetAxis("Mouse Y");
        var MouseX = Input.GetAxis("Mouse X");
        var rotation = Quaternion.Euler(cameraCenter.transform.rotation.eulerAngles.x - mouseY * sensitivity / 2, cameraCenter.transform.rotation.eulerAngles.y + MouseX * sensitivity, cameraCenter.transform.rotation.eulerAngles.z);

        cameraCenter.transform.rotation = rotation;
    }

    void Zooming()
    {
        var isScrolling = Input.GetAxis("Mouse ScrollWheel");
        if (isScrolling != 0f)
        {
            var scrollAmount = isScrolling * scrollSensitivity;
            scrollAmount *= zoomDistance * 0.3f;
            zoomDistance += -scrollAmount;
            zoomDistance = Mathf.Clamp(zoomDistance, zoomMin, zoomMax);
        }

        if (camDist.z != -zoomDistance)
        {
            camDist.z = Mathf.Lerp(camDist.z, -zoomDistance, Time.deltaTime * scrollDamping);
        }

        cam.transform.localPosition = camDist;
    }

    void AntiCameraClipping()
    {
        GameObject obj = new GameObject();
        obj.transform.SetParent(cam.transform.parent);
        obj.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, cam.transform.localPosition.z - collisionSensitivity);

        if (Physics.Linecast(cameraCenter.transform.position, obj.transform.position, out camHit))
        {
            cam.transform.position = camHit.point;
            var localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, cam.transform.localPosition.z + collisionSensitivity);
            cam.transform.localPosition = localPosition;
        }
        Destroy(obj);

        if (cam.transform.localPosition.z > -1f)
        {
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, -1f);
        }

    }





    // first version


    // public Transform target;

    // public float smoothSpeed = 0.125f;
    // // public float turnSpeed;
    // public Vector3 offset;

    // void LateUpdate()
    // {
    //     // dont do anything if we dont find any target
    //     if (!target)
    //         return;

    //     Vector3 desiredPosition = target.position + offset;
    //     Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    //     transform.position = smoothedPosition;

    //     transform.LookAt(target);

    //     // transform.RotateAround(target.transform.position, Vector3.up, Input.GetAxis("Mouse X") * turnSpeed);
    // }
}
