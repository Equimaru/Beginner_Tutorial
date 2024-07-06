using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FillUpSystemUI : MonoBehaviour
{
    [SerializeField] private Image minFillUpMarker;
    [SerializeField] private Image currentFillUpMarker;

    public void SetUpMinFillUpMarker(float minFillUpPercentage)
    {
        minFillUpMarker.DOFillAmount(minFillUpPercentage, 1f);
    }

    public void SetCurrentFillUpMarker(float currentFillUpPercentage)
    {
        currentFillUpMarker.DOFillAmount(currentFillUpPercentage, 1f);
    }
}
