using UnityEngine;

public class BackgroundFlyable : MonoBehaviour, IPausable
{
    public float velocity;
    public float startXPosition,
        endXPosition;

    private bool _isPaused;
    
    private Transform _objPos;
    
    void Start()
    {
        PauseSystem.Instance.AddPausable(this);
        _objPos = GetComponent<Transform>();
        _objPos.position = new Vector3(startXPosition, transform.position.y, _objPos.position.z);
    }

    void Update()
    {
        if (!_isPaused)
        {
            if (transform.position.x < endXPosition)
            {
                transform.Translate(Vector2.right * velocity * Time.deltaTime);
            }
            else
            {
                _objPos.position = new Vector3(startXPosition, transform.position.y, _objPos.position.z);
            }
        }
    }

   

    public void Pause()
    {
        _isPaused = true;
    }

    public void Resume()
    {
        _isPaused = true;
    }
}
