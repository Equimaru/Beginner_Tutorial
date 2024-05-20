using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class RedButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventDate)
    {
        transform.DOScale(new Vector3(1.4f, 1.4f), 0.5f);
    }
    
    public void OnPointerExit(PointerEventData eventDate)
    {
        transform.DOScale(Vector3.one, 0.5f);
    }
}
