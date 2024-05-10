using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
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

    private bool settingsPanelIsOpened = false;
    private bool animationInProgress = false;

    public void ToggleSettingsPanel()
    {
        if (!settingsPanelIsOpened && !animationInProgress)
        {
            StartCoroutine(OpenSettingsPanel());
        }
        else if (!animationInProgress) 
        {
            StartCoroutine(CloseSettingsPanel());
        }
    }

    private IEnumerator OpenSettingsPanel()
    {
        animationInProgress = true;
        settingsPanel.SetActive(true);
        settingsPanel.transform.DOScale(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        settingsPanelIsOpened = true;
        animationInProgress = false;
        yield return null;
    }


    private IEnumerator CloseSettingsPanel()
    {
        animationInProgress = true;
        settingsPanel.transform.DOScale(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        settingsPanel.SetActive(false);
        settingsPanelIsOpened = false;
        animationInProgress = false;
        yield return null;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("2DShooter");
    }



    public void ShowWinTitle()
    {
        winTitle.SetActive(true);
    }
}
