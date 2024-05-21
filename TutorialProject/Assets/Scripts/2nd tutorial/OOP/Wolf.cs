using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Creature
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Growl();
        }
    }
}
