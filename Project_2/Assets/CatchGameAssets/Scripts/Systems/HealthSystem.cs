using System;
using System.Collections.Generic;
using UnityEngine;

namespace Catch
{
    public class HealthSystem : MonoBehaviour
    {
        public Action OnNoHPLeft;

        [SerializeField] private GameObject hPIcon;
        private List<GameObject> _hP;
        private int _hPToSet;
        private int _health;

        public void Init(int health)
        {
            _hPToSet = health;
            SetHP();
        }
        
        private void SetHP()
        {
            _hP = new List<GameObject>();
            Vector3 heartPos = transform.position;

            for (int i = 0; i < _hPToSet; i++)
            {
                GameObject newHeart = Instantiate(hPIcon, heartPos, Quaternion.identity);
                newHeart.transform.SetParent(GameObject.FindGameObjectWithTag("HealthSystem").transform, true);
                _hP.Add(newHeart);
            }
        }

        public void DecreaseHealth()
        {
            int indexOfLastHeart = _hP.Count - 1;
            Destroy(_hP[indexOfLastHeart]);
            _hP.RemoveAt(indexOfLastHeart);

            if (indexOfLastHeart <= 0)
            {
                OnNoHPLeft?.Invoke();
            }
        }
    }

}

