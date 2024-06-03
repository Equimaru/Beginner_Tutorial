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
        }
        
        IEnumerator Spawn()
        {
            float waitTime = 1f;

            yield return new WaitForSeconds(waitTime);

            while (!gameOver)
            {
                if (_eatablesSpawned < _eatablesToSpawn)
                {
                    SpawnDroppable();
                    
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

        private void SpawnDroppable()
        {
            int factoryInUse = Random.Range(0, 2);

            var droppable = droppableFactories[factoryInUse].CreateDroppable();
            if (droppable.Type == ObjectType.Eatable)
            {
                _eatablesSpawned++;
            }
            droppable.OnCaught += ObjectOnCaught;
            droppable.OnDropped += ObjectOnDrop;
        }

        private void ObjectOnCaught(Droppable droppable)
        {
            droppable.OnCaught -= ObjectOnCaught;
            droppable.OnDropped -= ObjectOnCaught;
            if (droppable.Type == ObjectType.Eatable)
            {
                _scoreSystem.OnEatableCatch();
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
                _scoreSystem.OnEatableDrop();
            }
        }
    }
}