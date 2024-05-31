using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem : MonoBehaviour, IPausable
{
    public Action OnSpawn;
    public Action OnDeSpawn;
    
    public GameObject target;

    private float _spawnCooldown,
        _deSpawnCooldown;

    private Coroutine _spawnCoroutine;
    
    public bool IsPaused { get; set; }

    public void Init(float spawnCooldown, float timeToDeSpawn)
    {
        PauseSystem.Instance.AddPausable(this);
        _spawnCooldown = spawnCooldown;
        _deSpawnCooldown = timeToDeSpawn;
    }

    public void Pause()
    {
        IsPaused = true;
    }

    public void Resume()
    {
        IsPaused = false;
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
            yield return new CustomPauseInstruction(this, _spawnCooldown);
            Spawn();
        }
    }

    private IEnumerator DeSpawnAfterTime(GameObject obj)
    {
        if (obj != null)
        {
            yield return new CustomPauseInstruction(this, _deSpawnCooldown);
            Destroy(obj);
            OnDeSpawn?.Invoke();
        }
    }
}
