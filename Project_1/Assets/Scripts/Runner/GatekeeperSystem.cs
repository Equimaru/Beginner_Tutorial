using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Runner
{
    public class GatekeeperSystem : MonoBehaviour
    {
        public Action OnObstacleScored;

        private void OnTriggerEnter2D(Collider2D col)
        {
            GameObject obstacle = col.gameObject;
            if (obstacle.CompareTag("Obstacle"))
            {
                OnObstacleScored?.Invoke();
                Destroy(obstacle, 2f);
            }
        }
    }
}

