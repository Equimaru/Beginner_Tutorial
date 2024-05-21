using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon
{
    public string Name { get; private set; }

    private int _damage;

    private int Damage
    {
        get => _damage;
        set
        {
            if (value >= 0)
            {
                _damage = value;
            }
            else
            {
                Debug.LogWarning("Weapon damage can't be below 0!");
            }
        }
    }

    private float _attackSpeed;

    private float AttackSpeed
    {
        get => _attackSpeed;
        set
        {
            if (value >= 0)
            {
                _attackSpeed = value;
            }
            else
            {
                Debug.LogWarning("Weapon attack speed can't be below 0!");
            }
        }
    }

    private float _weight;
    private float Weight {
        get => _weight;
        set
        {
            if (value > 0)
            {
                _weight = value;
            }
            else
            {
                Debug.LogError("Weapon weight can't be zero or below!");
            }
        }
    }

    public void GetDamage()
    {
        Debug.Log(Damage);
    }

    public MeleeWeapon()
    {
        Debug.Log("You've created something... but... what is it?");
    }
    public MeleeWeapon(string name, int damage, float attackSpeed, float weight)
    {
        Name = name;
        Damage = damage;
        AttackSpeed = attackSpeed;
        Weight = weight;
        Debug.Log($"New weapon created: \nName: {Name} " +
                  $"\nDamage: {Damage} " +
                  $"\nAttack speed: {AttackSpeed} " +
                  $"\nWeight: {Weight}");
    }
}
