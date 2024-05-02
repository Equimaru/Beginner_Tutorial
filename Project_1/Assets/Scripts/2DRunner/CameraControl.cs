using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public void DoCameraShake()
    {
        transform.DOShakePosition(1f, Vector3.one);
    }
}
