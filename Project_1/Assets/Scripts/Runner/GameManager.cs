using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Runner
{
    public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Managers")] 
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private UIManager uIManager;

    [Header("Systems")] 
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private SpawnSystem spawnSystem;
    [SerializeField] private GatekeeperSystem gatekeeperSystem;
    [SerializeField] private CameraControlSystem cameraControlSystem;
    
    [Header("Controllers")]
    [SerializeField] private CharacterMovementController characterMovementController;
    [SerializeField] private DifficultyLevelController difficultyLevelController;
    [SerializeField] private TextureScrollingController textureScrollingController;
    
    
    
    

    [SerializeField] private GameObject gameOverPanel;

    
    
    
    private ButtonScalingUI _menuButtonScalingUI;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        
    }

    public void EndPlayPhase()
    {
        spawnSystem.gameOver = true;
        textureScrollingController.StopScrolling();
        uIManager.ShowScoreBoard();
        cameraControlSystem.DoCameraShake();
        gameOverPanel.SetActive(true);
    }
    
    

    public void Restart()
    {
        SceneManager.LoadScene("2DRunner");
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("2DRunnerMenu");
    }

    

    

}
}

