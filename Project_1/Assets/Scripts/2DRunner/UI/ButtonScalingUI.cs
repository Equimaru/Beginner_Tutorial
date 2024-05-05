using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScalingUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1.2f, 1.2f), 0.5f);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1f, 1f), 0.5f);
    }
    
}
