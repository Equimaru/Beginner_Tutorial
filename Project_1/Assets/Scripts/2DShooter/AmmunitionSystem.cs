using System.Collections.Generic;
using UnityEngine;

public class AmmunitionSystem : MonoBehaviour
{
    [SerializeField] private GameObject cartrige;

    private List<GameObject> _mag;
    [SerializeField] private float distBtwCartriges;


    public void MagazineInitialization(int ammoInMagazine)
    {
        _mag = new List<GameObject>();
        Vector3 cartrigePos = transform.position;

        for (int i = 0; i < ammoInMagazine; i++)
        {
            GameObject newCartrige = Instantiate(cartrige, cartrigePos, Quaternion.identity);
            newCartrige.transform.SetParent(GameObject.FindGameObjectWithTag("AmmoSys").transform, false);
            cartrigePos.x += distBtwCartriges;
            _mag.Add(newCartrige);
        }
    }

    public void ShotAttempt()
    {
        int indexOfLastCartrige = _mag.Count - 1;
        if (indexOfLastCartrige >= 0)
        {
            Destroy(_mag[indexOfLastCartrige]);
            _mag.RemoveAt(indexOfLastCartrige);
        }
        else
        {
            Debug.Log("No ammo left!");
        }
    }
}
