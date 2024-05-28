using System;
using System.Collections;
using System.Collections.Generic;
using Catch;
using TMPro;
using UnityEngine;

namespace Catch
{
    public class HealthSystem : MonoBehaviour
    {
        public Action OnNoHPLeft;

        [SerializeField] private GameObject hPIcon;
        private List<GameObject> _hP;
        private int _hPToSet;
        [SerializeField] private float distBtwIcons;
        
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
                heartPos.x += distBtwIcons;
                _hP.Add(newHeart);
            }
        }

        public void SignUpForActions(Garbage obj)
        {
            obj.OnCatchGarbage += DecreaseHealth;
        }

        private void DecreaseHealth()
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

