using UnityEngine;

namespace Runner
{
    public class Obstacle : MonoBehaviour
    {
        private DifficultyLevelController _difficultyLevelController;
        
        private Rigidbody2D _rb;

        private float _movementSpeed;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rb.velocity = Vector2.left * _movementSpeed;

            _difficultyLevelController.OnDifficultyIncrease += IncreaseObstacleSpeed;
        }

        public void Init(DifficultyLevelController difficultyLevelController, float movementSpeed)
        {
            _difficultyLevelController = difficultyLevelController;
            _movementSpeed = movementSpeed;
        }
        
        private void OnDestroy()
        {
            _difficultyLevelController.OnDifficultyIncrease -= IncreaseObstacleSpeed;
        }

        private void IncreaseObstacleSpeed()
        {
            _movementSpeed *= 1.05f;
        
            _rb.velocity = Vector2.left * _movementSpeed;
        }
    }
}

