using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject winTitle;

    public void ShowWinTitle()
    {
        winTitle.SetActive(true);
    }
}
