using UnityEngine;

public class CustomFunctions : MonoBehaviour
{
    private Transform _gameObjectTransform;
    
    private bool _isSpacePressed;

    private void Start()
    {
        TestFunctionForRotate(0,0,90);
    }
    private void Update()
    {
        _isSpacePressed = Input.GetKey(KeyCode.Space);
    }

    public bool IsSpacePressed()
    {
        return _isSpacePressed;
    }

    private void TestFunctionForRotate(float xAngle, float yAngle, float zAngle) // Not the best example, but
    {
        _gameObjectTransform = GetComponent<Transform>();
        _gameObjectTransform.Rotate(xAngle, yAngle, zAngle);
    }
}
