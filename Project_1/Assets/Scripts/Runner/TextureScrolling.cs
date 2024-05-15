using UnityEngine;

namespace Runner
{
    public class TextureScrolling : MonoBehaviour
    {
        private DifficultyLevelController _difficultyLevelController;
        
        private Material _material;

        public bool isScrolling = true;
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

            difficultyLevelController.OnDifficultyIncrease += IncreaseScrollSpeed;
        }
        
        private void IncreaseScrollSpeed()
        {
            scrollingSpeed *= 1.05f;

            _offset = new Vector2(scrollingSpeed, 0);
        }
    }
}

