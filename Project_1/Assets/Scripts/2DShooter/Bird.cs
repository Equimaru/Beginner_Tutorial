using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float velocity;
    public float startXPosition,
        endXPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(startXPosition, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < endXPosition)
        {
            transform.Translate(Vector2.right * velocity * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3 (startXPosition, transform.position.y, transform.position.z);
        }
    }
}
