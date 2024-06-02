using UnityEngine;

public class Level : MonoBehaviour
{
    [CreateAssetMenu(menuName = "Level")]
    public class DifficultySettings : ScriptableObject
    {
        [SerializeField] private int foodToSpawn;
        public int FoodToSpawn => foodToSpawn;
        [SerializeField] private float minSpawnTime;
        public float MinSpawnTime => minSpawnTime;
        [SerializeField] private float maxSpawnTime;
        public float MaxSpawnTime => maxSpawnTime;
        [SerializeField] private float minCatchPercentage;
        public float MinCatchPercentage => minCatchPercentage;
        [SerializeField] private Vector3 gravity;
        public Vector3 Gravity => gravity;
    
    }
}