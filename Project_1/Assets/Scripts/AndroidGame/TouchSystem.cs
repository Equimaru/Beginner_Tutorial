using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AndroidGame
{
    public class TouchSystem : MonoBehaviour
    {
        public Action OnBallTouched;
    
        private InputActions _gameInput;
        private Camera _cam;

        public LayerMask ballLayer;

        private void Start()
        {
            _cam = Camera.main;
        }

        public void Init(InputActions inputAction)
        {
            _gameInput = inputAction;
            _gameInput.Player.touchPress.performed += CheckForBallTouched;
        }


        private void CheckForBallTouched(InputAction.CallbackContext callbackContext)
        {
            Vector2 pressPosition = _gameInput.Player.touchPressPosition.ReadValue<Vector2>();
        
            RaycastHit2D hit = Physics2D.Raycast(_cam.ScreenToWorldPoint(new Vector3(pressPosition.x, pressPosition.y, 10)),
                Vector2.zero, 10f, ballLayer);

            if (hit.collider != null)
            {
                OnBallTouched?.Invoke();
                GameObject ball = hit.collider.gameObject;
                Destroy(ball);
            }
        }
    }

}
