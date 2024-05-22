using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    
    [Header("Config")] 
    [SerializeField] private float playerSpeed;
    
    [Header("Controllers")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private DifficultyController difficultyController;

    [Header("Managers")]
    [SerializeField] private AudioManager audioManager;

    [Header("Systems")] 
    [SerializeField] private SpawnSystem spawnSystem;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private HealthSystem healthSystem;
    

    private PlayerInputActions _playerInputActions;
    
    
    private void Start()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        
        playerController.Init(_playerInputActions, playerSpeed);
    }
    
}
