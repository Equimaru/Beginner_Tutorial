using UnityEngine;

public class IfElseStatements : MonoBehaviour
{

    private void Update()
    {
        PlayerBiasHandle();
        Debug.Log(direction);
    }
    
    private enum PlayerBiasDirection
    {
        Centered,
        Forward,
        Backward,
        Left,
        Right
    }

    private PlayerBiasDirection direction;
    
    private void PlayerBiasHandle()
    {
        if (Input.GetKey(KeyCode.W))
        {
            direction = PlayerBiasDirection.Forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = PlayerBiasDirection.Backward;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = PlayerBiasDirection.Left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = PlayerBiasDirection.Right;
        }
        else
        {
            direction = PlayerBiasDirection.Centered;
        }
    }
    
    
}
