using UnityEngine;

namespace Runner
{
    public class Obstacle : MonoBehaviour
    {
        private Rigidbody2D _rb;

        private SpawnSystem _spawnSystem;
    
        private float _movementSpeed;

        private float _destroyPosition = -15f;
        private float _scorePosition = -7.7f;

        private bool _scored = false;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _spawnSystem = GameObject.Find("ObstacleSpawner").GetComponent<SpawnSystem>();
        
            _movementSpeed = _spawnSystem.ObstacleSpeedOnSpawn;
            _rb.velocity = Vector2.left * _movementSpeed;

            DifficultyLevelController.OnDifficultyIncrease += IncreaseObstacleSpeed;
        }

        private void Update()
        {
            if (transform.position.x < _scorePosition && !_scored)
            {
                _scored = true;
                //GameManager.Instance.IncrementScore();
            }
        
            if (transform.position.x < _destroyPosition)
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            DifficultyLevelController.OnDifficultyIncrease -= IncreaseObstacleSpeed;
        }

        private void IncreaseObstacleSpeed()
        {
            _movementSpeed *= 1.05f;
        
            _rb.velocity = Vector2.left * _movementSpeed;
        }
    }
}

