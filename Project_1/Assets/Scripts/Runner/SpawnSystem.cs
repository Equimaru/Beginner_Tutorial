using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runner
{
    public class SpawnSystem : MonoBehaviour
    {
        [SerializeField] private GameObject[] obstacle;

        public bool gameOver = false;

        private float _minSpawnTime = 1f,
            _maxSpawnTime = 2f;

        public float ObstacleSpeedOnSpawn { get; private set; }

        private void Start()
        {
            ObstacleSpeedOnSpawn = 12f;
        
            StartCoroutine(Spawn());

            DifficultyLevelController.OnDifficultyIncrease += IncreaseObstacleSpeedOnSpawn;
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
            Instantiate(obstacle[random], transform.position, Quaternion.identity);
        }

        private void IncreaseObstacleSpeedOnSpawn()
        {
            ObstacleSpeedOnSpawn *= 1.05f;
        }
    }
}

