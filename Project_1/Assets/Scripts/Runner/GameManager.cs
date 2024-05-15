using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class GameManager : MonoBehaviour
{
    [Header("Config")] 
    [SerializeField] private float jumpForce;
    [SerializeField] private float minSpawnTime,
        maxSpawnTime;

    [SerializeField] private int maxDifficultyScore;
    
    
    [Header("Managers")] 
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private UIManager uIManager;

    [Header("Systems")] 
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private SpawnSystem spawnSystem;
    [SerializeField] private GatekeeperSystem gatekeeperSystem;
    [SerializeField] private CameraControlSystem cameraControlSystem;
    
    [Header("Controllers")]
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private DifficultyLevelController difficultyLevelController;
    [SerializeField] private TextureScrollingController textureScrollingController;
    [SerializeField] private PlayerAnimatorController playerAnimatorController;

    private InputActions _inputActions;
    
    private void Start()
    {
        _inputActions = new InputActions();
        _inputActions.Player.Enable();
        
        InitAllSystems();
        SignUpForActions();
    }

    private void InitAllSystems()
    {
        playerMovementController.Init(_inputActions, jumpForce);
        spawnSystem.Init(difficultyLevelController, minSpawnTime, maxSpawnTime);
        scoreSystem.Init(uIManager);
        difficultyLevelController.Init(maxDifficultyScore);
        
        
        TextureScrolling[] scrollingObjects = FindObjectsOfType<TextureScrolling>();
        foreach (TextureScrolling i in scrollingObjects)
        {
            i.Init(difficultyLevelController);
        }
        
        audioManager.PlayBackgroundMusic();
    }

    private void SignUpForActions()
    {
        playerMovementController.OnPlayerJump += OnPlayerJump;
        playerMovementController.OnPlayerLand += OnPlayerLand;
        playerMovementController.OnPlayerCrash += OnPlayerCrash;
        scoreSystem.OnRecordBreak += OnRecordScoreBroke; // Rename
        gatekeeperSystem.OnObstacleScored += OnObstacleScored;
        uIManager.OnRestartRequest += OnRestartRequest;
        uIManager.OnMenuExitRequest += OnMenuExitRequest;
    }

    private void OnPlayerJump()
    {
        audioManager.PlayJumpSound();
        playerAnimatorController.ProcessJumpAnimationGroup();
    }

    private void OnPlayerLand()
    {
        playerAnimatorController.ProcessLandAnimationGroup();
    }
    
    private void OnPlayerCrash()
    {
        audioManager.PlayCrashSound();
        cameraControlSystem.DoCameraShake();
        playerAnimatorController.ProcessDeathAnimationGroup();
        spawnSystem.gameOver = true;
        playerMovementController.TurnOffMovement();
        spawnSystem.StopObstaclesMovement();
        textureScrollingController.StopScrolling();
        uIManager.ShowScoreBoard();
        uIManager.ShowGameOverPanel();
    }

    private void OnRecordScoreBroke()
    {
        audioManager.PlayRecordBrokeSound();
        //Particle system implementation
    }

    private void OnObstacleScored()
    {
        scoreSystem.IncrementScore();
        difficultyLevelController.IncreaseGameSpeed();
    }
    
    private void OnRestartRequest()
    {
        SceneManager.LoadScene("2DRunner");
    }

    private void OnMenuExitRequest()
    {
        SceneManager.LoadScene("2DRunnerMenu");
    }
}
}

