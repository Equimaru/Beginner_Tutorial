using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSystem : MonoBehaviour
{
    public Action OnShotHit;
    public Action OnShotMiss;

    private AmmunitionSystem ammunitionSystem;
    
    public LayerMask droneLayer;
    
    private Camera _cam;
    
    private InputActions _gameInput;
    private bool _gameEnded;

    private void Start()
    {
        _cam = Camera.main;
    }

    public void Init(InputActions gameInput, AmmunitionSystem ammoSystem)
    {
        ammunitionSystem = ammoSystem;
        _gameInput = gameInput;
        _gameInput.Player.Weapon.performed += CheckForHit;
    }

    private void OnDisable() // Get rid of
    {
        _gameInput.Player.Weapon.performed -= CheckForHit;
    }

    private void CheckForHit(InputAction.CallbackContext callbackContext)
    {
        if (!ammunitionSystem.CheckForAmmo()) return;

        RaycastHit2D[] hits =
            Physics2D.RaycastAll(_cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)),
                Vector2.zero, 10f, droneLayer);

        if (hits.Length != 0)
        {
            foreach (RaycastHit2D hit in hits)
            {
                OnShotHit?.Invoke();
                GameObject drone = hit.collider.gameObject;
                Destroy(drone);
            }
        }
        else
        {
            OnShotMiss?.Invoke();
        }
    }
}
