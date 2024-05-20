using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{

    public float rotationSpeed;

    private void OnMouseDrag()
    {
        float x = Input.GetAxis("Mouse X") * rotationSpeed;
        float y = Input.GetAxis("Mouse Y") * rotationSpeed;
        
        transform.Rotate(Vector3.down, x, Space.World);
        transform.Rotate(Vector3.right, y, Space.World);
    }
}
