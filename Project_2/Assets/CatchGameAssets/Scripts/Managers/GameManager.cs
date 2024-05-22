using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private PlayerController playerController;


    [Header("Config")] 
    [SerializeField] private float playerSpeed;
    
    private PlayerInputActions _playerInputActions;
    
    
    private void Start()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        
        playerController.Init(_playerInputActions, playerSpeed);
    }
    
}
