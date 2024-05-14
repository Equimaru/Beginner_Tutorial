using DG.Tweening;
using UnityEngine;

namespace Runner
{
    public class CameraControlSystem : MonoBehaviour
    {
        public void DoCameraShake()
        {
            transform.DOShakePosition(1f, Vector3.one);
        }
    }
}
