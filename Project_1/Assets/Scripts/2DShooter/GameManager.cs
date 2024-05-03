using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private InputActions _gameInput;
    
    public GameObject winTitle;

    [Header("Config")] 
    [SerializeField] private float spawnCooldown;
    [SerializeField] private float timeToDispawnTarget;
    [SerializeField] private int ammoInMag;
    
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
        
        cursorManager.SetGameCursor();
        spawnSystem.StartSpawn();
    }

    private void InitAllSystems()
    {
        weaponSystem.Init(_gameInput);
        spawnSystem.Init(spawnCooldown, timeToDispawnTarget);
        ammunitionSystem.MagazineInitialization(ammoInMag);
    }
    
    public void EndGame()
    {
        spawnSystem.StopSpawn();
        winTitle.SetActive(true);
        cursorManager.SetDefaultCursor();
    }

    public void ProcessShotAttempt(bool hit)
    {
        ammunitionSystem.ShotAttempt();
        if (hit)
        {
            audioManager.PlayHitSound();
            scoreSystem.IncrementScore();
        }
        else
        {
            audioManager.PlayMissSound();
        }
    }
}
