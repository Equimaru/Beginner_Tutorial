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
        
        
        TextureScrolling[] scrollingObjects = FindObjectsOfType<TextureScrolling>();
        foreach (TextureScrolling i in scrollingObjects)
        {
            i.Init(difficultyLevelController);
        }
    }

    private void SignUpForActions()
    {
        playerMovementController.OnPlayerJump += OnPlayerJump;
        playerMovementController.OnPlayerLand += OnPlayerLand;
        playerMovementController.OnPlayerCrash += OnPlayerCrash;
        scoreSystem.OnRecordBreak += OnRecordScoreBroke; // Rename
        gatekeeperSystem.OnObstacleScored += OnObstacleScored;
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
    }
    
    public void OnRestartRequest()
    {
        SceneManager.LoadScene("2DRunner");
    }

    public void OnOpenMenuRequest()
    {
        SceneManager.LoadScene("2DRunnerMenu");
    }
}
}

