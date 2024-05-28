using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catch
{
    public class ShopManager : MonoBehaviour
    {
        private CashSystem _cashSystem;

        public void Init(CashSystem cashSystem)
        {
            _cashSystem = cashSystem;
        }
    }
}

