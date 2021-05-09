using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform pepper;
    public Vector3 offset;
    public Camera cam;
    public SpriteRenderer floorRenderer;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;
    public float smoothSpeed = 0.125f;
    public float cameraZoom = 0.2f;

    private Vector3 dragOrigin;

    Vector3 currentVelocity = new Vector3(0, 0);

    private void Awake()
    {
        mapMinX = floorRenderer.transform.position.x - floorRenderer.bounds.size.x / 2f;
        mapMaxX = floorRenderer.transform.position.x + floorRenderer.bounds.size.x / 2f;
        mapMinY = floorRenderer.transform.position.y - floorRenderer.bounds.size.y / 2f;
        mapMaxY = floorRenderer.transform.position.y + floorRenderer.bounds.size.y / 2f;
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }

    private void Update()
    {
        PanCamera();
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            cam.orthographicSize = Mathf.Max(cam.orthographicSize - cameraZoom, 4f);
            // offset.z++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            cam.orthographicSize = Mathf.Min(cam.orthographicSize + cameraZoom, 12.5f);
            //offset.z--;
        }
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = pepper.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothSpeed);
        // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = ClampCamera(smoothedPosition);
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position = ClampCamera(cam.transform.position + difference);
        }
    }

}
