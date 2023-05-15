using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        var touches = Input.touches;

        switch (touches.Length)
        {
            case 1:
                Drag(touches);
                break;
            case >= 2:
                Zoom(touches);
                break;
        }
    }

    private void Drag(Touch[] touches)
    {
        var touch = Input.GetTouch(0);
        cam.transform.position -= new Vector3(touch.deltaPosition.x, 0, touch.deltaPosition.y) * 0.001f;
    }

    private void Zoom(Touch[] touches)
    {
        var prevPos0 = touches[0].position - touches[0].deltaPosition;
        var prevPos1 = touches[1].position - touches[1].deltaPosition;
        var prevDistance = Vector2.Distance(prevPos0, prevPos1);
        var currentDistance = Vector2.Distance(touches[0].position, touches[1].position);
        var deltaDistance = currentDistance - prevDistance;

        if (cam.orthographic)
        {
            cam.orthographicSize -= deltaDistance * .1f;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 2, 15);
        }
        else
        {
            cam.transform.position += Vector3.forward * deltaDistance * .01f;
            var z = Mathf.Clamp(cam.transform.position.z, -10, -1);
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, z);
        }
    }
}
