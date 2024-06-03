using UnityEngine;
using UnityEngine.UI;

public class FillUpSystemUI : MonoBehaviour
{
    [SerializeField] private Image minFillUpMarker;
    [SerializeField] private Image currentFillUpMarker;

    public void SetUpMinFillUpMarker(float minFillUpPercentage)
    {
        minFillUpMarker.fillAmount = minFillUpPercentage;
    }

    public void SetCurrentFillUpMarker(float currentFillUpPercentage)
    {
        currentFillUpMarker.fillAmount = currentFillUpPercentage;
    }
}
