using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public static TargetSpawner Instance;
    
    public GameObject target;

    private float _timeBtwSpawn = 2f;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    public void Spawn()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-4f, 4f);

        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        Instantiate(target, randomPosition, Quaternion.identity);
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnLoop());
    }
    
    public void StopSpawn()
    {
        StopCoroutine(SpawnLoop());
    }
    
    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_timeBtwSpawn);
        }
    }
}
