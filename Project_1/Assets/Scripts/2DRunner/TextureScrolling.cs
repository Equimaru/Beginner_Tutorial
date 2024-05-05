using UnityEngine;

public class TextureScrolling : MonoBehaviour
{
    private Material _material;

    public bool isScrolling = true;
    [SerializeField] private float scrollingSpeed;

    private Vector2 _offset;
    void Start()
    {
        _material = GetComponent<Renderer>().material;

        _offset = new Vector2(scrollingSpeed, 0);

        DifficultyLevelController.OnDifficultyIncrease += IncreaseScrollSpeed;
    }

    void Update()
    {
        if (isScrolling)
        {
            _material.mainTextureOffset += _offset * Time.deltaTime;
        }
    }

    private void IncreaseScrollSpeed()
    {
        scrollingSpeed *= 1.05f;

        _offset = new Vector2(scrollingSpeed, 0);
    }
}
