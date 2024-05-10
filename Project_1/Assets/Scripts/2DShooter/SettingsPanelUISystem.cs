using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsPanelUISystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Action OnMouseOverUIEnter;
    public Action OnMouseOverUIExit;


    public void OnPointerEnter(PointerEventData eventData)
    {
        OnMouseOverUIEnter?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnMouseOverUIExit?.Invoke();
    }
}
