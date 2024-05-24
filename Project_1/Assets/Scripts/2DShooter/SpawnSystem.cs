using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem : MonoBehaviour, IPausable
{
    public Action OnSpawn;
    public Action OnDeSpawn;
    
    public GameObject target;

    private float _spawnCooldown;
    private float _timeToDeSpawn;

    private bool _isPaused;

    private Coroutine _spawnCoroutine = null;

    public void Init(float spawnCooldown, float timeToDeSpawn)
    {
        PauseSystem.Instance.AddPausable(this);
        _spawnCooldown = spawnCooldown;
        _timeToDeSpawn = timeToDeSpawn;
    }

    public void Pause()
    {
        _isPaused = true;
    }

    public void Resume()
    {
        _isPaused = false;
    }
    
    private void Spawn()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY;
        if (randomX is > -1.4f and < 1.4f)
        {
            randomY = Random.Range(-4f, 2.4f);
        }
        else if (randomX < -5.8f)
        {
            randomY = Random.Range(-2.7f, 4f);
        }
        else if (randomX > 6.6f)
        {
            randomY = Random.Range(-4f, 2.7f);
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
            if (_isPaused)
            {
                yield return new WaitForSeconds(_spawnCooldown);
            }
            else
            {
                Spawn();
                yield return new WaitForSeconds(_spawnCooldown);
            }
        }
    }

    private IEnumerator DeSpawnAfterTime(GameObject obj)
    {
        yield return new WaitForSeconds(_timeToDeSpawn);
        if (obj != null && !_isPaused)
        {
            Destroy(obj);
            OnDeSpawn?.Invoke();
        }
        else if (obj != null && _isPaused)
        {
            yield return new WaitUntil(() => _isPaused == false);
            yield return new WaitForSeconds(_timeToDeSpawn);
            Destroy(obj);
            OnDeSpawn?.Invoke();
        }
    }
}
