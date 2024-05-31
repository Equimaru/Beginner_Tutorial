using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Action OnSFXVolumeToggled;
    public Action OnMusicVolumeToggled;
    public Action OnGameRestartRequest; // Should i use request keyword in this case?
    public Action OnGameExitRequest;
    
    [SerializeField] private GameObject winTitle;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject musicButton;
    [SerializeField] private TextMeshProUGUI musicButtonText;
    [SerializeField] private GameObject sFXButton;
    [SerializeField] private TextMeshProUGUI sFXButtonText;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    private bool _sFXVolumeOn = true;
    private bool _musicVolumeOn = true;
    
    private bool _settingsPanelIsOpened = false;
    private bool _animationInProgress = false;

    public void ToggleSettingsPanel()
    {
        if (!_settingsPanelIsOpened && !_animationInProgress)
        {
            StartCoroutine(OpenSettingsPanel());
        }
        else if (!_animationInProgress) 
        {
            StartCoroutine(CloseSettingsPanel());
        }
    }

    private IEnumerator OpenSettingsPanel()
    {
        PauseSystem.Instance.Pause();
        _animationInProgress = true;
        settingsPanel.SetActive(true);
        settingsPanel.transform.DOScale(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        _settingsPanelIsOpened = true;
        _animationInProgress = false;
        yield return null;
    }

    private IEnumerator CloseSettingsPanel()
    {
        PauseSystem.Instance.Resume();
        _animationInProgress = true;
        settingsPanel.transform.DOScale(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        settingsPanel.SetActive(false);
        _settingsPanelIsOpened = false;
        _animationInProgress = false;
        yield return null;
    }

    public void ShowWinTitle()
    {
        winTitle.SetActive(true);
    }

    public void ToggleSFXVolume()
    {
        OnSFXVolumeToggled?.Invoke();
        if (_sFXVolumeOn)
        {
            sFXButtonText.text = "Off";
            _sFXVolumeOn = false;
        }
        else
        {
            sFXButtonText.text = "On";
            _sFXVolumeOn = true;
        }
    }

    public void ToggleMusicVolume()
    {
        OnMusicVolumeToggled?.Invoke();
        if (_musicVolumeOn)
        {
            musicButtonText.text = "Off";
            _musicVolumeOn = false;
        }
        else
        {
            musicButtonText.text = "On";
            _musicVolumeOn = true;
        }
    }

    public void RequestGameRestart()
    {
        OnGameRestartRequest?.Invoke();
    }

    public void RequestGameExit()
    {
        OnGameExitRequest?.Invoke();
    }
}
