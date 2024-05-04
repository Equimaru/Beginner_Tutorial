using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private InputActions _gameInput;

    [Header("Config")] 
    [SerializeField] private int scoreToWin;
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

    private void InitAllSystems()
    {
        scoreSystem.Init(scoreToWin);
        weaponSystem.Init(_gameInput);
        spawnSystem.Init(spawnCooldown, dispawnTime);
        ammunitionSystem.Init(ammoInMag, reloadTime);
    }

    private void SignUpForActions()
    {
        ScoreSystem.OnFinishScoreReached += OnFinishScoreReached;
        WeaponSystem.OnShotHit += OnShotHit;
        WeaponSystem.OnShotMiss += OnShotMiss;
        AmmunitionSystem.OnReloadStarted += OnReloadStarted;
        AmmunitionSystem.OnReloadEnded += OnReloadEnded;
        SpawnSystem.OnSpawn += OnSpawn;
        SpawnSystem.OnDispawn += OnDispawn;
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
        Debug.Log("My grandma can do better than you!");
    }
}
