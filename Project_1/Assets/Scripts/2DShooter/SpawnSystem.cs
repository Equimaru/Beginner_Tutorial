using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject target;

    private float _spawnCooldown;
    private float _timeToDispawn;
    

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
    }

    public void StartDispawnProcedure(GameObject obj) //Make coroutine in Target instead
    {
        Destroy(obj, _timeToDispawn);
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnLoop());
    }
    
    public void StopSpawn()
    {
        StopCoroutine(SpawnLoop());
    }
    
    public IEnumerator SpawnLoop()
    {
        while (Application.isPlaying)
        {
            Spawn();
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }
}
