using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{

    public static ObstacleSpawner Instance;
    
    [SerializeField] private GameObject[] obstacle;

    public bool gameOver = false;

    private float _minSpawnTime = 1f,
        _maxSpawnTime = 2f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        float waitTime = 1f;

        yield return new WaitForSeconds(waitTime);

        while (!gameOver)
        {
            SpawnObstacle();

            waitTime = Random.Range(_minSpawnTime, _maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void SpawnObstacle()
    {
        int random = Random.Range(0, obstacle.Length);
        Instantiate(obstacle[random], transform.position, Quaternion.identity);
    }
}
