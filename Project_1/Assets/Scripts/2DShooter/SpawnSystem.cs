using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem : MonoBehaviour
{
    public Action OnSpawn;
    public Action OnDispawn;
    
    public GameObject target;

    private float _spawnCooldown;
    private float _timeToDispawn;

    private Coroutine spawnCoroutine = null;

    public void Init(float spawnCooldown, float timeToDispawn)
    {
        _spawnCooldown = spawnCooldown;
        _timeToDispawn = timeToDispawn;
    }
    
    private void Spawn()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-4f, 4f);

        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        Instantiate(target, randomPosition, Quaternion.identity);
        OnSpawn?.Invoke();
    }

    public void StartSpawn()
    {
        spawnCoroutine = StartCoroutine(SpawnLoop());
    }
    
    public void StopSpawn()
    {
        StopCoroutine(spawnCoroutine);
    }

    public void StartDispawnProcedure(GameObject obj)
    {
        StartCoroutine(DispawnAfterTime(obj));
    }
    
    private IEnumerator SpawnLoop()
    {
        while (Application.isPlaying)
        {
            Spawn();
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    private IEnumerator DispawnAfterTime(GameObject obj)
    {
        yield return new WaitForSeconds(_timeToDispawn);
        if (obj != null)
        {
            Destroy(obj);
            OnDispawn?.Invoke();
        }
    }
}
