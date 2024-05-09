using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject winTitle;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject MusicButton;
    [SerializeField] private GameObject sFXButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button exitButton;

    private bool settingsPanelIsOpened;

    public void ToggleSettingsPanel()
    {
        if (settingsPanelIsOpened)
        {

        }
    }

    private void OpenSettingsPanel()
    {

    }



    public void ShowWinTitle()
    {
        winTitle.SetActive(true);
    }
}
