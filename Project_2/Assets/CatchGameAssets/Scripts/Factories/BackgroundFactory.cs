using System.Collections.Generic;
using Catch;
using UnityEngine;

public class BackgroundFactory : MonoBehaviour
{
    [SerializeField] private List<GameObject> backgroundPrefabs;

    public Background CreateBackground()
    {
        int rnd = Random.Range(0, backgroundPrefabs.Count);
        Vector3 pos = transform.position;
        var newBackground = Instantiate(backgroundPrefabs[rnd], pos, Quaternion.identity);
        return newBackground.GetComponent<Background>();
    }
}
