using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Catch
{
    public class SpawnSystem : MonoBehaviour
    {
        public Action OnAllObjectsSpawned;

        [SerializeField] private List<DroppableFactory> droppableFactories;

        private Vector2 _screenSize;
        [SerializeField] private float gapAtBorder;
        
        private Vector3 _position;
        private LevelController _levelController;
        private HealthSystem _healthSystem;
        private ScoreSystem _scoreSystem;

        public bool gameOver;

        private int _eatablesToSpawn,
            _eatablesSpawned;

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
                if (_eatablesSpawned < _eatablesToSpawn)
                {
                    SpawnDrop();
                    _eatablesSpawned++;

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
            _eatablesToSpawn = objectsToSpawn;
            _eatablesSpawned = 0;
            _minSpawnTime = minSpawnTime;
            _maxSpawnTime = maxSpawnTime;
            
            _spawnCoroutine = StartCoroutine(Spawn());
        }

        private void SpawnDrop()
        {
            _position = transform.position;
            if (Camera.main != null) 
                _screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            float randomX = Random.Range(_screenSize.x * -1 + gapAtBorder, _screenSize.x - gapAtBorder);
<<<<<<< Updated upstream
            
            int random = Random.Range(0, food.Length);
            GameObject newObj = Instantiate(food[random], new Vector3(randomX, _position.y, _position.z), Quaternion.identity);
            var drop = newObj.GetComponent<Drop>();
            drop.OnCaught += ObjectOnCaught;
           
            
        }
        
        private void ObjectOnCaught(Drop drop)
        {
            drop.OnCaught -= ObjectOnCaught;
            if (drop.Type == ObjectType.Eatable)
=======

            int factoryInUse = Random.Range(0, 2);

            var droppable = droppableFactories[factoryInUse].CreateDroppable(new Vector3(randomX, _position.y, _position.z));
            droppable.OnCaught += ObjectOnCaught;
            droppable.OnDropped += ObjectOnDrop;
        }

        private void ObjectOnCaught(Droppable droppable)
        {
            droppable.OnCaught -= ObjectOnCaught;
            droppable.OnDropped -= ObjectOnCaught;
            if (droppable.Type == ObjectType.Eatable)
>>>>>>> Stashed changes
            {
                _scoreSystem.OnFoodCatch();
            }
            else if (droppable.Type == ObjectType.Uneatable)
            {
                _healthSystem.DecreaseHealth();
            }
        }

        private void ObjectOnDrop(Droppable droppable)
        {
            droppable.OnCaught -= ObjectOnCaught;
            droppable.OnDropped -= ObjectOnCaught;
            if (droppable.Type == ObjectType.Eatable)
            {
                _scoreSystem.OnFoodDrop();
            }
        }
    }
}