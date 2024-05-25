using System;
using System.Collections;
using System.Collections.Generic;
using Catch;
using TMPro;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public Action OnRanOutOfHealth;
    
    [SerializeField] private TextMeshProUGUI healthText;
    
    private int _health;

    private List<ObjectToCatch> _objectsList;

    public void Init(int health)
    {
        _health = health;
        healthText.text = "Health: " + _health;
    }

    public void AddToObjList(ObjectToCatch obj)
    {
        _objectsList.Add(obj);
        obj.OnBadCatchOrLost += DecreaseHealth;
    }

    private void DecreaseHealth()
    {
        _health = Mathf.Clamp(_health - 1, 0, 2147483647);
        healthText.text = "Health: " + _health;

        if (_health <= 0)
        {
            OnRanOutOfHealth?.Invoke();
        }
    }
}
