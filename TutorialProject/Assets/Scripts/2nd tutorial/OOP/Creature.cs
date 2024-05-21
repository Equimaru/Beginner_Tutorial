using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public string Name { get; set; }
    private int _health;
    public int Health
    {
        get => _health;
        set
        {
            if (value > 0)
            {
                _health = value;
            }
            else
            {
                Debug.LogWarning("Health cant be zero or below!");
            }
        }
    }

    public Creature()
    {
        
    }
    
    public Creature(string name, int health)
    {
        Name = name;
        Health = health;
        Debug.Log($"Creature {Name} created with {Health} HP.");
    }

    protected void Growl()
    {
        Debug.Log("Krya");
    }
}
