using UnityEngine;

public class BackgroundFlyable : MonoBehaviour, IPausable
{
    public float velocity;
    public float startXPosition,
        endXPosition;
    
    public bool IsPaused { get; set; }

    private Transform _objPos;
    
    void Start()
    {
        PauseSystem.Instance.AddPausable(this);
        _objPos = GetComponent<Transform>();
        _objPos.position = new Vector3(startXPosition, transform.position.y, _objPos.position.z);
    }

    void Update()
    {
        if (!IsPaused)
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
        IsPaused = true;
    }

    public void Resume()
    {
        IsPaused = false;
    }
}
