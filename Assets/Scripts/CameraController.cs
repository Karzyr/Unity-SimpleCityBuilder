using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //change size to zoom in/out
    Camera cam;
    private readonly int maxZoom = 0;
    private readonly int minZoom = 10;
    private readonly float scale = 0.3f;

    private Vector3 mouseOriginPoint;
    private Vector3 cameraOffset;
    private bool dragging = false;

    private void Start() {
        cam = Camera.main;
    }
    private void LateUpdate() {
        //Old Zoom in/out code    
        /*if(camera.orthographicSize > maxZoom && Input.mouseScrollDelta.y > 0) {
            camera.orthographicSize -= Input.mouseScrollDelta.y * scale;
        }
        if (camera.orthographicSize < minZoom && Input.mouseScrollDelta.y < 0) {
            camera.orthographicSize -= Input.mouseScrollDelta.y * scale;
        }*/

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - Input.mouseScrollDelta.y * (scale * cam.orthographicSize*.1f),2.5f,50f);

        //Check Middle Mouse Button
        if (Input.GetMouseButton(2)) {
            cameraOffset = (cam.ScreenToWorldPoint(Input.mousePosition)) - transform.position;
            if (!dragging) {
                dragging = true;
                mouseOriginPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else dragging = false;

        if (dragging) {
            transform.position = mouseOriginPoint - cameraOffset;
        }

        
    }


}
