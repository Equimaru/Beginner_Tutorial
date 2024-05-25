using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catch
{
    public class SpawnSystem : MonoBehaviour
    {
        [SerializeField] private GameObject[] food;

        private Vector3 _position;
        private DifficultyController _difficultyController;
        private HealthSystem _healthSystem;
        private ScoreSystem _scoreSystem;

        public bool gameOver = false;

        private float _minSpawnTime = 1f,
            _maxSpawnTime = 2f;


        public void Init(DifficultyController difficultyController, HealthSystem healthSystem, ScoreSystem scoreSystem, float minSpawnTime, float maxSpawnTime)
        {
            _difficultyController = difficultyController;
            _healthSystem = healthSystem;
            _scoreSystem = scoreSystem;
            _minSpawnTime = minSpawnTime;
            _maxSpawnTime = maxSpawnTime;
            _position = transform.position;
            Debug.Log(_position);
            
            StartCoroutine(Spawn());
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
            int random = Random.Range(0, food.Length);
            float randomX = Random.Range(-9f, 9f);
            GameObject newFood = Instantiate(food[random], new Vector3(randomX, _position.y, _position.z), Quaternion.identity);
            _healthSystem.AddToObjList(newFood.GetComponent<ObjectToCatch>());
            _scoreSystem.AddToObjList(newFood.GetComponent<ObjectToCatch>());
        }
    }
}

