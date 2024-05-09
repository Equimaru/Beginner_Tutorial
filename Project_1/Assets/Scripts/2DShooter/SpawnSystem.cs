using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem : MonoBehaviour
{
    public Action OnSpawn;
    public Action OnDeSpawn;
    
    public GameObject target;

    private float _spawnCooldown;
    private float _timeToDeSpawn;

    private Coroutine _spawnCoroutine = null;

    public void Init(float spawnCooldown, float timeToDeSpawn)
    {
        _spawnCooldown = spawnCooldown;
        _timeToDeSpawn = timeToDeSpawn;
    }
    
    private void Spawn()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY;
        if (randomX is > -1.4f and < 1.4f)
        {
            randomY = Random.Range(-4f, 2.4f);
        }
        else if (randomX is < -5.8f)
        {
            randomY = Random.Range(-2.7f, 4f);
        }
        else
        {
            randomY = Random.Range(-4f, 4f);
        }

        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        GameObject targetRef = Instantiate(target, randomPosition, Quaternion.identity);
        StartCoroutine(DeSpawnAfterTime(targetRef));
        OnSpawn?.Invoke();
    }

    public void StartSpawn()
    {
        _spawnCoroutine = StartCoroutine(SpawnLoop());
    }
    
    public void StopSpawn()
    {
        StopCoroutine(_spawnCoroutine);
    }

    private IEnumerator SpawnLoop()
    {
        while (Application.isPlaying)
        {
            Spawn();
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    private IEnumerator DeSpawnAfterTime(GameObject obj)
    {
        yield return new WaitForSeconds(_timeToDeSpawn);
        if (obj != null)
        {
            Destroy(obj);
            OnDeSpawn?.Invoke();
        }
    }
}
