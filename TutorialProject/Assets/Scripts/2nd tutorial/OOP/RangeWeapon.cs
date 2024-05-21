using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RangeWeapon
{
    public string name;
    public int damage;
    public float attackSpeed;
    public float weight;

    public void PrintWeaponDetail()
    {
        Debug.Log("Weapon details:" +
                  $"\nName: {name}" +
                  $"\nDamage: {damage}" +
                  $"\nAttack speed: {attackSpeed}" +
                  $"\nWeight: {weight}");
    }
}
