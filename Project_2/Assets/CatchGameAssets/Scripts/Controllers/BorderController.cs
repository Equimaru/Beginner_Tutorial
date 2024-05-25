using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catch
{
    public class BordersController : MonoBehaviour
    {
        [SerializeField] private GameObject leftBorder;
        [SerializeField] private GameObject rightBorder;

        private Vector2 _screenSize;
        void Start()
        {
            BordersSetup();
        }

        private void BordersSetup()
        {
            if (Camera.main != null) 
                _screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            Vector3 leftBorderPos = leftBorder.transform.position;
            leftBorderPos.x = _screenSize.x * -1 - (leftBorder.GetComponent<Collider>().bounds.size.x / 2);
            leftBorder.transform.position = leftBorderPos;
            Vector3 rightBorderPos = rightBorder.transform.position;
            rightBorderPos.x = _screenSize.x + (rightBorder.GetComponent<Collider>().bounds.size.x / 2);
            rightBorder.transform.position = rightBorderPos;
        
        }
    }

}

