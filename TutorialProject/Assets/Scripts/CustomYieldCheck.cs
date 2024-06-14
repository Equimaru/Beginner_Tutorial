using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomYieldCheck : MonoBehaviour
{
    private IEnumerator DoSomething()
    {
        yield return new WaitForSeconds(5);
    }

    private void Do()
    {
    }
}
