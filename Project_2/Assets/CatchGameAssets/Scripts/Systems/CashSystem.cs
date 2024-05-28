using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catch
{
    public class CashSystem : MonoBehaviour
    {
        private int _currentMoneyAmount;
        public int CurrentMoneyAmount => _currentMoneyAmount;

        public void AddMoney(int moneyToAdd)
        {
            _currentMoneyAmount += moneyToAdd;
        }

        public bool IsAbleToPurchase(int price)
        {
            if (_currentMoneyAmount >= price)
            {
                _currentMoneyAmount -= price;
                return true;
            }
            return false;
        }
    }
}

