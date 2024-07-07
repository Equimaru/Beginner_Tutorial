using UnityEngine;

namespace Catch
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;

        private Rigidbody _rb;
        private Transform _transform;
    
        private float _playerSpeed;
        private float _inputAxis;

        private bool _gameOver;

        private void Update()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.x > Screen.width / 2)
                {
                    _inputAxis = 1;
                }
                else _inputAxis = -1;
            }
            else _inputAxis = 0;
#elif UNITY_EDITOR
            _inputAxis = _playerInputActions.Player.Movement.ReadValue<float>();
#endif

        }

        private void FixedUpdate()
        {
            if (!_gameOver)
            {
                _rb.velocity = new Vector3(_inputAxis * _playerSpeed, 0, 0);
            }
        }
        
        public void Init(PlayerInputActions playerInputActions, float playerSpeed)
        {
            _rb = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
        
            _playerInputActions = playerInputActions;
            _playerSpeed = playerSpeed;
        }

        public void EndGamePhase()
        {
            _rb.velocity = Vector3.zero;
            _gameOver = true;
        }

        public void StartGamePhase()
        {
            _gameOver = false;
        }
    }
}

