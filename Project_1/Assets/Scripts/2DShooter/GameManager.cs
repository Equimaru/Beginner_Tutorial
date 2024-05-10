using System;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private InputActions _gameInput;
    
    [Header("Current Settings Preset")]
    [Dropdown("Difficulties")]
    public string Difficulty; //In PascalCase for proper visualization in Inspector

    private DifficultySettings SelectedSettings
    {
        get
        {
            return Settings.FirstOrDefault(x => x.Difficulty == Difficulty);
        }
    }

    private DifficultySettings _currentSettings;

    [Tooltip("Fill to use game presets, otherwise custom config will be applied")]
    [SerializeField] private bool usePreset;
    
    [Header("Custom Config")] 
    [SerializeField] private int scoreToWin;
    [SerializeField] private int scoreLossOnMiss;
    [SerializeField] private int scoreLossOnDeSpawn;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private float deSpawnTime;
    [SerializeField] private int ammoInMag;
    [SerializeField] private float reloadTime;
    
    [Header("Systems")] 
    [SerializeField] private AmmunitionSystem ammunitionSystem;
    [SerializeField] private WeaponSystem weaponSystem;
    [SerializeField] private SpawnSystem spawnSystem;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private SettingsPanelUISystem settingsPanelUISystem;
    
    [Header("Managers")] 
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private CursorManager cursorManager;
    [SerializeField] private UIManager uIManager;

    [Header("Settings Presets")]
    [SerializeField] private List<DifficultySettings> Settings; //In PascalCase or proper visualization in Inspector
    private string[] Difficulties
    {
        get
        {
            return Settings.Select(x => x.Difficulty).ToArray();
        }
    }

    private void Awake()
    {
        if (usePreset)
        {
            LoadGameDifficultySettings();
            InitGameDifficultySettings();
        }
    }

    private void Start()
    {
        _gameInput = new InputActions();
        _gameInput?.Player.Enable();
        
        InitAllSystems();
        SignUpForActions();
        
        cursorManager.SetGameCursor();
        spawnSystem.StartSpawn();
    }

    private void LoadGameDifficultySettings()
    {
        _currentSettings = SelectedSettings;
    }
    
    private void InitGameDifficultySettings()
    {
        scoreToWin = _currentSettings.ScoreToWin;
        scoreLossOnMiss = _currentSettings.ScoreLossOnMiss;
        scoreLossOnDeSpawn = _currentSettings.ScoreLossOnDeSpawn;
        spawnCooldown = _currentSettings.SpawnCooldown;
        deSpawnTime = _currentSettings.DeSpawnTime;
    }
    
    private void InitAllSystems()
    {
        scoreSystem.Init(scoreToWin);
        weaponSystem.Init(_gameInput, ammunitionSystem);
        spawnSystem.Init(spawnCooldown, deSpawnTime);
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
        spawnSystem.OnDeSpawn += OnDeSpawn;
        settingsPanelUISystem.OnMouseOverUIEnter += OnMouseOverUIEnter;
        settingsPanelUISystem.OnMouseOverUIExit += OnMouseOverUIExit;
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
        scoreSystem.DeCreaseScore(scoreLossOnMiss);
        audioManager.PlayMissSound();
    }

    private void OnReloadStarted()
    {
        
    }

    private void OnReloadEnded()
    {
        audioManager.PlayReloadSound();
    }

    private void OnSpawn()
    {
        audioManager.PlaySpawnSound();
    }

    private void OnDeSpawn()
    {
        audioManager.PlayDeSpawnSound();
        scoreSystem.DeCreaseScore(scoreLossOnDeSpawn);
    }

    private void OnMouseOverUIEnter()
    {
        weaponSystem.isMouseOverUI = true;
    }

    private void OnMouseOverUIExit()
    {
        weaponSystem.isMouseOverUI = false;
    }
}
