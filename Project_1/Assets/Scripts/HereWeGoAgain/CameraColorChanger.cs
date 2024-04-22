using UnityEngine;

public class CameraColorChanger : MonoBehaviour
{
    public Color[] colorArray;

    private float _timer;
    public float delay;
    
    private void Start()
    {
        Debug.Log(colorArray.Length);
    }

    private void Update()
    {
        if (_timer >= delay)
        {
            ChangeColor();
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    private void ChangeColor()
    {
        int rnd = Random.Range(0, colorArray.Length);
        if (Camera.main != null)
        {
            Camera.main.backgroundColor = colorArray[rnd];
        }
    }
}
