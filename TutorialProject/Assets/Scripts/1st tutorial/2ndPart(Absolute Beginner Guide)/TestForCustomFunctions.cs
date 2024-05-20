using UnityEngine;

public class TestForCustomFunctions : MonoBehaviour
{
    private CustomFunctions _customFunctions;

    private void Start()
    {
        _customFunctions = GetComponent<CustomFunctions>();
    }
    
    private void Update()
    {
        if (_customFunctions.IsSpacePressed())
        {
            Debug.Log("Jump");
        }
    }
}
