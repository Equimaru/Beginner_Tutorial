using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Catch
{
    public class SpawnSystem : MonoBehaviour
    {
        public Action OnAllSpawnedObjectsGone;

        private RandomGenerator _randomGenerator;

        [SerializeField] private List<FallingItemFactory> fallingItemFactory;

        private Vector2 _screenSize;
        
        private LevelController _levelController;
        private HealthSystem _healthSystem;
        private ScoreSystem _scoreSystem;

        public bool gameOver;

        private int _goodItemsToSpawn,
            _goodItemsSpawned,
            _goodItemsCatchOrDropped,
            _maxGoodItemsCatchOrDropped;

        private float _minSpawnTime = 1f,
            _maxSpawnTime = 2f;

        private Coroutine _spawnCoroutine;


        public void Init(HealthSystem healthSystem, ScoreSystem scoreSystem, float goodItemSpawnChance, float badItemSpawnChance)
        {
            _healthSystem = healthSystem;
            _scoreSystem = scoreSystem;
            
            _randomGenerator = new RandomGenerator(new int[] {0, 1}, new float[] {goodItemSpawnChance, badItemSpawnChance});
        }

        private async void AsyncSpawn()
        {
            while (!gameOver)
            {
                await Task.Delay(2000);

                if (_goodItemsSpawned < _goodItemsToSpawn)
                {
                    SpawnDroppable();
                    
                    var timeToWait = Random.Range(_minSpawnTime, _maxSpawnTime);
                    await Task.Delay((int) (timeToWait * 1000f));
                }

                await Task.Yield();
            }
        }
        
        IEnumerator Spawn()
        {
            float waitTime = 1f;

            yield return new WaitForSeconds(waitTime);

            while (!gameOver)
            {
                if (_goodItemsSpawned < _goodItemsToSpawn)
                {
                    SpawnDroppable();
                    
                    waitTime = Random.Range(_minSpawnTime, _maxSpawnTime);
                    yield return new WaitForSeconds(waitTime);
                }
                else
                {
                    StopCoroutine(_spawnCoroutine);
                    yield return null;
                }
            }
        }

        public void SetParameters(float minSpawnTime, float maxSpawnTime, int objectsToSpawn)
        {
            _goodItemsToSpawn = objectsToSpawn;
            _maxGoodItemsCatchOrDropped = _goodItemsToSpawn;
            _goodItemsCatchOrDropped = 0;
            _goodItemsSpawned = 0;
            _minSpawnTime = minSpawnTime;
            _maxSpawnTime = maxSpawnTime;

            gameOver = false;
            //_spawnCoroutine = StartCoroutine(Spawn());
            AsyncSpawn();
        }

        private void SpawnDroppable()
        {
            int factoryInUse = _randomGenerator.GetRandomResult();

            var fallingItem = fallingItemFactory[factoryInUse].CreateFallingItem();
            if (fallingItem.Type == ObjectType.Eatable)
            {
                _goodItemsSpawned++;
            }
            fallingItem.OnCaught += ObjectOnCaught;
            fallingItem.OnDropped += ObjectOnDrop;
        }

        private void ObjectOnCaught(FallingItem fallingItem)
        {
            fallingItem.OnCaught -= ObjectOnCaught;
            fallingItem.OnDropped -= ObjectOnCaught;
            if (fallingItem.Type == ObjectType.Eatable)
            {
                _scoreSystem.OnGoodItemCatch();
                _goodItemsCatchOrDropped++;
                CheckForAllItemsGone();
            }
            else if (fallingItem.Type == ObjectType.Uneatable)
            {
                _healthSystem.DecreaseHealth();
            }
        }

        private void ObjectOnDrop(FallingItem fallingItem)
        {
            fallingItem.OnCaught -= ObjectOnCaught;
            fallingItem.OnDropped -= ObjectOnCaught;
            if (fallingItem.Type == ObjectType.Eatable)
            {
                _scoreSystem.OnGoodItemDrop();
                _goodItemsCatchOrDropped++;
                CheckForAllItemsGone();
            }
        }

        private void CheckForAllItemsGone()
        {
            if (_goodItemsCatchOrDropped == _maxGoodItemsCatchOrDropped)
            {
                OnAllSpawnedObjectsGone?.Invoke();
            }
        }
    }
}