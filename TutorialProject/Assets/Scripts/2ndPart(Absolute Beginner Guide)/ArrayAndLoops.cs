using UnityEngine;

public class ArrayAndLoops : MonoBehaviour
{
    public GameObject[] objectsArray;
    public Color[] coloursArray;

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            objectsArray[i].GetComponent<Renderer>().material.color = coloursArray[i];
        }
    }

    private void Update()
    {
        CountIfShiftPressed();

        if (Input.GetKey(KeyCode.F))
        {
            DestroyAllObjects();
        }
    }

    private void CountIfShiftPressed() //WARNING: Almost Malware, press Shift on ur risk
    {
        int i = 0;
        while (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log(i++);
        }
    }

    private void DestroyAllObjects()
    {
        foreach (GameObject n in objectsArray)
        {
            Destroy(n);
        }
    }
}
