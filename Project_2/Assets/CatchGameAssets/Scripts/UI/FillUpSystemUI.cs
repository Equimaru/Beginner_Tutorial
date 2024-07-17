using DG.Tweening;
using UnityEngine.UI;
using Zenject;

public class FillUpSystemUI
{
    [Inject] private Image _minFillUpMarker;
    [Inject] private Image _currentFillUpMarker;

    public void SetUpMinFillUpMarker(float minFillUpPercentage)
    {
        _minFillUpMarker.DOFillAmount(minFillUpPercentage, 1f);
    }

    public void SetCurrentFillUpMarker(float currentFillUpPercentage)
    {
        _currentFillUpMarker.DOFillAmount(currentFillUpPercentage, 1f);
    }
}
