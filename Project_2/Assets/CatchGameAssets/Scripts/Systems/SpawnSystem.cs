using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Catch
{
    public class SpawnSystem : MonoBehaviour
    {
        public Action OnAllObjectsSpawned;
        
        [SerializeField] private GameObject[] food;

        private Vector2 _screenSize;
        [SerializeField] private float gapAtBorder;
        
        private Vector3 _position;
        private LevelController _levelController;
        private HealthSystem _healthSystem;
        private ScoreSystem _scoreSystem;

        public bool gameOver;

        private int _objectsToSpawn,
            _objectsSpawned;

        private float _minSpawnTime = 1f,
            _maxSpawnTime = 2f;

        private Coroutine _spawnCoroutine;


        public void Init(HealthSystem healthSystem, ScoreSystem scoreSystem)
        {
            _healthSystem = healthSystem;
            _scoreSystem = scoreSystem;
            _position = transform.position;
        }
        
        IEnumerator Spawn()
        {
            float waitTime = 1f;

            yield return new WaitForSeconds(waitTime);

            while (!gameOver)
            {
                if (_objectsSpawned < _objectsToSpawn)
                {
                    SpawnDrop();
                    _objectsSpawned++;

                    waitTime = Random.Range(_minSpawnTime, _maxSpawnTime);
                    yield return new WaitForSeconds(waitTime);
                }
                else
                {
                    StopCoroutine(_spawnCoroutine);
                    OnAllObjectsSpawned?.Invoke();
                    yield return null;
                }
            }
        }

        public void SetParameters(float minSpawnTime, float maxSpawnTime, int objectsToSpawn)
        {
            _objectsToSpawn = objectsToSpawn;
            _objectsSpawned = 0;
            _minSpawnTime = minSpawnTime;
            _maxSpawnTime = maxSpawnTime;
            
            _spawnCoroutine = StartCoroutine(Spawn());
        }

        private void SpawnDrop()
        {
            if (Camera.main != null) 
                _screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            float randomX = Random.Range(_screenSize.x * -1 + gapAtBorder, _screenSize.x - gapAtBorder);
            
            int random = Random.Range(0, food.Length);
            GameObject newObj = Instantiate(food[random], new Vector3(randomX, _position.y, _position.z), Quaternion.identity);
            var drop = newObj.GetComponent<Drop>();
            drop.OnCaught += ObjectOnCaught;
            
            
        }

        private void ObjectOnCaught(Drop drop)
        {
            
            
            drop.OnCaught -= ObjectOnCaught;
            if (drop.Type == ObjectType.Eatable)
            {
                _scoreSystem.OnFoodCatch();
            }
            else if (drop.Type == ObjectType.Uneatable)
            {
                _healthSystem.DecreaseHealth();
            }
        }
    }
}

