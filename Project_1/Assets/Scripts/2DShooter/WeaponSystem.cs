using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public LayerMask droneLayer;
    
    private Camera _cam;
    
    private InputActions _gameInput;
    private bool _gameEnded;

    private void Start()
    {
        _cam = Camera.main;
    }

    public void Init(InputActions gameInput)
    {
        _gameInput = gameInput;
        _gameInput.Player.Weapon.performed += _ => CheckForHit(); //Get rid of anonymous event
    }
    
    private void CheckForHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(_cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero, droneLayer);

        if (hit.collider != null)
        {
            GameManager.Instance.ProcessShotAttempt(true);
            GameObject drone = hit.collider.gameObject;
            Destroy(drone);
        }
        else
        {
            GameManager.Instance.ProcessShotAttempt(true);
        }
    }
}
