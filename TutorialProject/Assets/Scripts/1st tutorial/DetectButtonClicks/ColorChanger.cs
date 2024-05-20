using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    public GameObject cube;

    private Button _blueButton;
    void Start()
    {
        _blueButton = GameObject.Find("BlueButton").GetComponent<Button>();
        _blueButton.onClick.AddListener(MakeCubeBlue);
    }

    void Update()
    {
        
    }


    public void MakeCubeRed()
    {
        cube.GetComponent<Renderer>().material.color = Color.red;
    }
    
    public void MakeCubeBlue()
    {
        cube.GetComponent<Renderer>().material.color = Color.blue;
    }
}
