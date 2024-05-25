using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runner
{
    public class SpawnSystem : MonoBehaviour
    {
        [SerializeField] private GameObject[] obstacle;
        
        private DifficultyLevelController _difficultyLevelController;
        private RunnerParticleSystem _runnerParticleSystem;

        public bool gameOver = false;

        private float _minSpawnTime = 1f,
            _maxSpawnTime = 2f;

        public float ObstacleSpeedOnSpawn { get; private set; }

        public void Init(DifficultyLevelController difficultyLevelController, RunnerParticleSystem runnerParticleSystem, float minSpawnTime, float maxSpawnTime)
        {
            _difficultyLevelController = difficultyLevelController;
            _runnerParticleSystem = runnerParticleSystem;
            _minSpawnTime = minSpawnTime;
            _maxSpawnTime = maxSpawnTime;
            
            ObstacleSpeedOnSpawn = 12f;
            StartCoroutine(Spawn());

            _difficultyLevelController.OnDifficultyIncrease += IncreaseObstacleSpeedOnSpawn;
        }
        
        IEnumerator Spawn()
        {
            float waitTime = 1f;

            yield return new WaitForSeconds(waitTime);

            while (!gameOver)
            {
                SpawnObstacle();

                waitTime = Random.Range(_minSpawnTime, _maxSpawnTime);
                yield return new WaitForSeconds(waitTime);
            }
        }

        private void SpawnObstacle()
        {
            int random = Random.Range(0, obstacle.Length);
            GameObject newObstacle = Instantiate(obstacle[random], transform.position, Quaternion.identity);
            Obstacle newObstacleScript = newObstacle.GetComponent<Obstacle>();
            newObstacleScript.Init(_difficultyLevelController, _runnerParticleSystem, ObstacleSpeedOnSpawn);
        }

        private void IncreaseObstacleSpeedOnSpawn()
        {
            ObstacleSpeedOnSpawn *= 1.05f;
        }

        public void StopObstaclesMovement()
        {
            Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
            foreach (Obstacle i in obstacles)
            {
                i.StopMovement();
            }
        }
    }
}

