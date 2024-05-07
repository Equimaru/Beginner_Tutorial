using UnityEngine;
using UnityEngine.SceneManagement;

namespace AndroidGame
{
    public class GameManager : MonoBehaviour
    {
        
        private InputActions _gameInput;

        [Header("Config")] 
        [SerializeField] private int scoreToWin;
        
        
        [Header("Systems")]
        [SerializeField] private TouchSystem touchSystem;
        [SerializeField] private ScoreSystem scoreSystem;
        [SerializeField] private UISystem uISystem;
        
        private void Start()
        {
            _gameInput = new InputActions();
            _gameInput?.Player.Enable();
            
            InitAllSystems();
            SighUpForActions();
        }

        private void InitAllSystems()
        {
            touchSystem.Init(_gameInput);
            scoreSystem.Init(scoreToWin);
        }

        private void SighUpForActions()
        {
            touchSystem.OnBallTouched += OnBallTouched;
            scoreSystem.OnFinishScoreReached += OnFinishScoreReached;
            uISystem.OnRestartPressed += OnRestartPressed;
        }

        private void OnBallTouched()
        {
            scoreSystem.IncrementScore();
        }

        private void OnFinishScoreReached()
        {
            uISystem.ShowGameOverUI();
        }

        private void OnRestartPressed()
        {
            SceneManager.LoadScene("AndroidGame", LoadSceneMode.Single);
        }
    }
}
