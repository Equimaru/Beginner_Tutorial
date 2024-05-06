using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionSystem : MonoBehaviour
{
    public Action OnReloadStarted;
    public Action OnReloadEnded;
    
    [SerializeField] private GameObject cartridge;
    [SerializeField] private float distBtwCartridges;
    
    private List<GameObject> _mag;
    private float _reloadTime;
    private int _ammoInMag;
    public bool isReloading;

    public void Init(int ammoInMag, float reloadTime)
    {
        _ammoInMag = ammoInMag;
        _reloadTime = reloadTime;
        Reload();
    }

    private void Reload()
    {
        _mag = new List<GameObject>();
        Vector3 cartridgePos = transform.position;

        for (int i = 0; i < _ammoInMag; i++)
        {
            GameObject newCartridge = Instantiate(cartridge, cartridgePos, Quaternion.identity);
            newCartridge.transform.SetParent(GameObject.FindGameObjectWithTag("AmmoSys").transform, false);
            cartridgePos.x += distBtwCartridges;
            _mag.Add(newCartridge);
        }
    }

    public bool CheckForAmmo()
    {
        bool isCheckPositive = (_mag.Count > 0);
        int indexOfLastCartridge = _mag.Count - 1;

        if (isCheckPositive)
        {
            Destroy(_mag[indexOfLastCartridge]);
            _mag.RemoveAt(indexOfLastCartridge);
        }

        if (_mag.Count == 0 && !isReloading)
        {
            isReloading = true;
            OnReloadStarted?.Invoke();
            StartCoroutine(StartReload());
        }

        return (isCheckPositive);
    }

    IEnumerator StartReload()
    {
        yield return new WaitForSeconds(_reloadTime);
        isReloading = false;
        Reload();
        OnReloadEnded?.Invoke();
    }
}
