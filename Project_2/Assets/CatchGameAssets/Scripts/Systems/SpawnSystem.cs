using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Catch
{
    public class SpawnSystem : MonoBehaviour
    {
        public Action OnAllSpawnedObjectsGone;

        private RandomGenerator _randomGenerator;
        [Inject] private readonly GoodItem.Factory _goodItemFactory;
        [Inject] private readonly BadItem.Factory _badItemFactory;

        private List<GameObject> _fallingItemList = new List<GameObject>();

        private Vector2 _screenSize;
        
        [Inject] private LevelController _levelController;
        [Inject] private HealthSystem _healthSystem;
        [Inject] private ScoreSystem _scoreSystem;

        public bool gameOver;

        private int _goodItemsToSpawn,
            _goodItemsSpawned,
            _goodItemsCatchOrDropped,
            _maxGoodItemsCatchOrDropped;

        private float _minSpawnTime = 1f,
            _maxSpawnTime = 2f;

        private Coroutine _spawnCoroutine;

        public void Init(float goodItemSpawnChance, float badItemSpawnChance)
        {
            _randomGenerator = new RandomGenerator(new int[] {0, 1}, new float[] {goodItemSpawnChance, badItemSpawnChance});
        }

        private IEnumerator Spawn()
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
                    StopSpawn();
                    yield return null;
                }
            }
        }

        public void StopSpawn()
        {
            StopCoroutine(_spawnCoroutine);
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
            _spawnCoroutine = StartCoroutine(Spawn());
        }

        private void SpawnDroppable()
        {
            int factoryInUse = _randomGenerator.GetRandomResult();
            float defaultSpawnHeight = 7f;
            FallingItem fallingItem;
            
            if (factoryInUse == 0)
            {
                fallingItem = _goodItemFactory.Create(transform, new Vector3(GetRandomXPos(), defaultSpawnHeight, 0));
            }
            else
            {
                fallingItem = _badItemFactory.Create(transform, new Vector3(GetRandomXPos(), defaultSpawnHeight, 0));
            }
            
            _fallingItemList.Add(fallingItem.gameObject);
            if (fallingItem.Type == ObjectType.Eatable)
            {
                _goodItemsSpawned++;
            }
            fallingItem.OnCaught += ObjectOnCaught;
            fallingItem.OnDropped += ObjectOnDrop;
        }

        public void ClearFallingItems()
        {
            foreach (var item in _fallingItemList)
            {
                Destroy(item);
            }
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
        
        private float GetRandomXPos()
        {
            float gapAtBorder = 1f;
            if (Camera.main != null)
            {
                Vector2 screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
                float randomX = Random.Range(screenSize.x * -1 + gapAtBorder, screenSize.x - gapAtBorder);
                return randomX;
            }
            Debug.LogError("There is no camera in scene.");
            return 0f;
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