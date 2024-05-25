using UnityEngine;

namespace Runner
{
    public class Obstacle : MonoBehaviour
    {
        private DifficultyLevelController _difficultyLevelController;
        private RunnerParticleSystem _runnerParticleSystem;
        
        private Rigidbody2D _rb;

        private float _movementSpeed;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Init(DifficultyLevelController difficultyLevelController, RunnerParticleSystem runnerParticleSystem, float movementSpeed)
        {
            _difficultyLevelController = difficultyLevelController;
            _runnerParticleSystem = runnerParticleSystem;
            _movementSpeed = movementSpeed;
            _rb.velocity = Vector2.left * _movementSpeed;

            _difficultyLevelController.OnDifficultyIncrease += IncreaseObstacleSpeed;
        }
        
        private void OnDestroy()
        {
            _difficultyLevelController.OnDifficultyIncrease -= IncreaseObstacleSpeed;
        }

        public void CallExplosionOnYourself()
        {
            _runnerParticleSystem.DoExplosion(transform.position);
        }
        
        private void IncreaseObstacleSpeed()
        {
            _movementSpeed *= 1.05f;
        
            _rb.velocity = Vector2.left * _movementSpeed;
        }

        public void StopMovement()
        {
            _rb.velocity = Vector2.zero;
        }
    }
}

