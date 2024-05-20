using UnityEngine;

public class CaseSwitch : MonoBehaviour
{
    public int age;
    void Update()
    {
        switch (age)
        {
            case <= 12:
                Debug.Log("You are child");
                break;
            case > 12 and < 20:
                Debug.Log("You are teenager");
                break;
            case >= 20 and < 60:
                Debug.Log("You are adult");
                break;
            case >= 60:
                Debug.Log("You are pensioner");
                break;
        }
    }
}
