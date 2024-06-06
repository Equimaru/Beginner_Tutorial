using System.Collections.Generic;
using UnityEngine;

namespace Catch
{
    public class BackgroundFactory : MonoBehaviour
    {
        [SerializeField] private List<Background> backgroundPrefabs;

        public Background CreateBackground()
        {
            int prefabInUse = Random.Range(0, backgroundPrefabs.Count);
            Vector3 pos = transform.position;
            var newBackground = Instantiate(backgroundPrefabs[prefabInUse], pos, new Quaternion(-90f,90f,-90f,90f));
            return newBackground;
        }
    }
}

