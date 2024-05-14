using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Config")] 
    [SerializeField] private float jumpForce;
    
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
    [SerializeField] private PlayerAnimatorController playerAnimatorController;

    private InputActions _inputActions;
    
    

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
        _inputActions = new InputActions();
        _inputActions.Player.Enable();
        
        InitAllSystems();
        SignUpForActions();
    }

    private void InitAllSystems()
    {
        characterMovementController.Init(_inputActions, jumpForce);
    }

    private void SignUpForActions()
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

