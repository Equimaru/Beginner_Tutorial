using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private InputActions _gameInput;

    private enum SetGameDifficulty
    {
        Easy,
        Normal,
        Hard
    }
    
    
    
    [Header("Game difficulty current preset")] 
    [SerializeField] private SetGameDifficulty setGameDifficulty;
    [Tooltip("Fill to use game presets, otherwise custom config will be applied")]
    [SerializeField] private bool useGDPresets;
    
    [Header("Config")] 
    [SerializeField] private int scoreToWin;
    [SerializeField] private int scoreLossOnMiss;
    [SerializeField] private int scoreLossOnDispawn;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private float dispawnTime;
    [SerializeField] private int ammoInMag;
    [SerializeField] private float reloadTime;
    
    [Header("Systems")] 
    [SerializeField] private AmmunitionSystem ammunitionSystem;
    [SerializeField] private WeaponSystem weaponSystem;
    [SerializeField] private SpawnSystem spawnSystem;
    [SerializeField] private ScoreSystem scoreSystem;
    
    [Header("Managers")] 
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private CursorManager cursorManager;
    [SerializeField] private UIManager uIManager;

    [Header("Settings presets")] 
    [SerializeField] private DifficultySettings easy;
    [SerializeField] private DifficultySettings normal;
    [SerializeField] private DifficultySettings hard;
    
    private DifficultySettings _currentSettings;

    private void Awake()
    {
        if (useGDPresets)
        {
            LoadGameDifficultySettings();
            InitGameDifficultySettings();
        }
    }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        _gameInput = new InputActions();
        _gameInput?.Player.Enable();
        
        InitAllSystems();
        SignUpForActions();
        
        cursorManager.SetGameCursor();
        spawnSystem.StartSpawn();
    }

    private void LoadGameDifficultySettings()
    {
        if (setGameDifficulty == SetGameDifficulty.Easy)
        {
            _currentSettings = easy;
        }
        else if (setGameDifficulty == SetGameDifficulty.Normal)
        {
            _currentSettings = normal;
        }
        else
        {
            _currentSettings = hard;
        }
    }
    
    private void InitGameDifficultySettings()
    {
        scoreToWin = _currentSettings.ScoreToWin;
        scoreLossOnMiss = _currentSettings.ScoreLossOnMiss;
        scoreLossOnDispawn = _currentSettings.ScoreLossOnDispawm;
        spawnCooldown = _currentSettings.SpawnCooldown;
        dispawnTime = _currentSettings.DispawnTime;
    }
    
    private void InitAllSystems()
    {
        scoreSystem.Init(scoreToWin);
        weaponSystem.Init(_gameInput);
        spawnSystem.Init(spawnCooldown, dispawnTime);
        ammunitionSystem.Init(ammoInMag, reloadTime);
    }

    private void SignUpForActions()
    {
        scoreSystem.OnFinishScoreReached += OnFinishScoreReached;
        weaponSystem.OnShotHit += OnShotHit;
        weaponSystem.OnShotMiss += OnShotMiss;
        ammunitionSystem.OnReloadStarted += OnReloadStarted;
        ammunitionSystem.OnReloadEnded += OnReloadEnded;
        spawnSystem.OnSpawn += OnSpawn;
        spawnSystem.OnDispawn += OnDispawn;
    }

    private void OnFinishScoreReached()
    {
        spawnSystem.StopSpawn();
        uIManager.ShowWinTitle();
        cursorManager.SetDefaultCursor();
        
        weaponSystem.gameObject.SetActive(false);
        ammunitionSystem.gameObject.SetActive(false);
    }

    private void OnShotHit()
    {
        audioManager.PlayHitSound();
        scoreSystem.IncrementScore();
    }

    private void OnShotMiss()
    {
        scoreSystem.DicreaseScore(scoreLossOnMiss);
        audioManager.PlayMissSound();
    }

    private void OnReloadStarted()
    {
        weaponSystem.gameObject.SetActive(false);
        audioManager.PlayReloadSound();
    }

    private void OnReloadEnded()
    {
        weaponSystem.gameObject.SetActive(true);
        weaponSystem.Init(_gameInput);
    }

    private void OnSpawn()
    {
        Debug.Log("I'm here!");
    }

    private void OnDispawn()
    {
        scoreSystem.DicreaseScore(scoreLossOnDispawn);
        Debug.Log("My grandma can do better than you!");
    }
}
