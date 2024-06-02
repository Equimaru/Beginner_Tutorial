using UnityEngine;

namespace Runner
{
    public class GameLoader : MonoBehaviour
    {
        [SerializeField] private GameObject scoreSystem;

        private void Awake()
        {
            if (ScoreSystem.Instance == null)
            {
                Instantiate(scoreSystem);
            }
        }
    }
}

