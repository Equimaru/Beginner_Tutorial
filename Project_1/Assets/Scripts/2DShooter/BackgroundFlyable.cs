using UnityEngine;

public class BackgroundFlyable : MonoBehaviour
{
    public float velocity;
    public float startXPosition,
        endXPosition;

    private Transform _objPos;
    
    void Start()
    {
        _objPos = GetComponent<Transform>();
        _objPos.position = new Vector3(startXPosition, transform.position.y, _objPos.position.z);
    }

    void Update()
    {
        if (transform.position.x < endXPosition)
        {
            transform.Translate(Vector2.right * velocity * Time.deltaTime);
        }
        else
        {
            _objPos.position = new Vector3 (startXPosition, transform.position.y, _objPos.position.z);
        }
    }
}
