using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float zoomSpeed2D;
    private float _min2DSize = 1f;
    private float _max2DSize = 10f;
    
    [SerializeField] private float zoomSpeed3D;
    private float _min3DSize = 1f;
    private float _max3DSize = 80f;

    private void Update()
    {
        if (Camera.main == null) return;
        if (Camera.main.orthographic)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                Camera.main.orthographicSize -= zoomSpeed2D * Time.deltaTime;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                Camera.main.orthographicSize += zoomSpeed2D * Time.deltaTime;
            }

            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, _min2DSize, _max2DSize);
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                Camera.main.fieldOfView -= zoomSpeed3D * Time.deltaTime;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                Camera.main.fieldOfView += zoomSpeed3D * Time.deltaTime;
            }

            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, _min3DSize, _max3DSize);
        }
    }
}
