using UnityEngine;

namespace Runner
{
    public class TextureScrolling : MonoBehaviour
    {
        private DifficultyLevelController _difficultyLevelController;
        
        private Material _material;

        public bool isScrolling;
        [SerializeField] private float scrollingSpeed;

        private Vector2 _offset;

        void Update()
        {
            if (isScrolling)
            {
                _material.mainTextureOffset += _offset * Time.deltaTime;
            }
        }

        public void Init(DifficultyLevelController difficultyLevelController)
        {
            _difficultyLevelController = difficultyLevelController;
            
            _material = GetComponent<Renderer>().material;
            _offset = new Vector2(scrollingSpeed, 0);
            isScrolling = true;

            difficultyLevelController.OnDifficultyIncrease += IncreaseScrollSpeed;
        }

        public void InitForMenu()
        {
            _material = GetComponent<Renderer>().material;
            _offset = new Vector2(scrollingSpeed, 0);
            isScrolling = true;
        }
        
        private void IncreaseScrollSpeed()
        {
            scrollingSpeed *= 1.05f;

            _offset = new Vector2(scrollingSpeed, 0);
        }
    }
}

