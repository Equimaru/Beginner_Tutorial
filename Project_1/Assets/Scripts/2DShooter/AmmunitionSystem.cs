using UnityEngine;

public class AmmunitionSystem : MonoBehaviour
{
    [SerializeField] private GameObject cartrige;

    private GameObject[] _mag;
    [SerializeField] private float distBtwCartriges;


    public void MagazineInitialization(int ammoInMagazine)
    {
        _mag = new GameObject[ammoInMagazine];
        Vector3 cartrigePos = transform.position;

        foreach (GameObject i in _mag)
        {
            GameObject newCartrige = Instantiate(cartrige, cartrigePos, Quaternion.identity);
            newCartrige.transform.SetParent(GameObject.FindGameObjectWithTag("AmmoSys").transform, false);
            cartrigePos.x += distBtwCartriges;
        }
    }

    public void ShotAttempt()
    {
        
    }
}
