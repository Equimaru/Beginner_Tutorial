using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public GameObject winTitle;
    public GameObject target;

    #region Audio
    private AudioSource _audioSource;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip missSound;
    [SerializeField] private AudioClip reload;
    #endregion

    #region Ammo
    [SerializeField] private GameObject cartrige_1;
    [SerializeField] private GameObject cartrige_2;
    [SerializeField] private GameObject cartrige_3;
    [SerializeField] private GameObject cartrige_4;
    [SerializeField] private GameObject cartrige_5;
    #endregion

    [SerializeField] private TextMeshProUGUI scoreText;
    private Camera _cam;

    private InputActions _gameInput;

    private int _ammoInMag;
    private int _score = 0;
    private bool _win = false;
    public LayerMask droneLayer;

    private void Start()
    {
        _ammoInMag = 5;
        AmmunitionInitialization();

        _gameInput = new InputActions();
        _gameInput?.Player.Enable();

        _audioSource = GetComponent<AudioSource>();

        _cam = Camera.main;
        if (_cam != null)
        {
            Debug.Log(_cam.name);
        }

        InvokeRepeating(nameof(Spawn), 1f, 1f);

        _gameInput.Player.Weapon.performed += i => CheckForHit();
    }

    private void Update()
    {
        if (_win == true)
        {
            CancelInvoke(nameof(Spawn));
        }
    }

    private void Spawn()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-4f, 4f);

        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        Instantiate(target, randomPosition, Quaternion.identity);
    }

    private void IncrementScore()
    {
        _score++;
        Debug.Log(_score);

        scoreText.text = _score.ToString();

        if (_score < 10) return;

        _win = true;
        winTitle.SetActive(true);
        CursorManager.Instance.SetDefaultCursor();
    }

    private void CheckForHit()
    {
        if (_ammoInMag == 0) return;

        RaycastHit2D hit = Physics2D.Raycast(_cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero, droneLayer);

        if (hit.collider != null)
        {
            IncrementScore();
            _audioSource.clip = hitSound;
            _audioSource.Play();
            GameObject drone = hit.collider.gameObject;
            Destroy(drone);
        }
        else
        {
            _audioSource.clip = missSound;
            _audioSource.Play();
        }

        AmmunitionManagement();
    }

    private void AmmunitionInitialization()
    {
        cartrige_1.SetActive(true);
        cartrige_2.SetActive(true);
        cartrige_3.SetActive(true);
        cartrige_4.SetActive(true);
        cartrige_5.SetActive(true);
    }


    private void AmmunitionManagement()
    {
        switch (_ammoInMag)
        {
            case 1:
                cartrige_1.SetActive(false);
                _ammoInMag = 0;
                StartCoroutine(waitForReload());
                break;
            case 2:
                cartrige_2.SetActive(false);
                _ammoInMag = 1;
                break;
            case 3:
                cartrige_3.SetActive(false);
                _ammoInMag = 2;
                break;
            case 4:
                cartrige_4.SetActive(false);
                _ammoInMag = 3;
                break;
            case 5:
                cartrige_5.SetActive(false);
                _ammoInMag = 4;
                break;
        }
    }

    private IEnumerator waitForReload()
    {
        yield return new WaitForSeconds(1);
        _audioSource.clip = reload;
        _audioSource.Play();
        AmmunitionInitialization();
        yield return new WaitForSeconds(2);
        _ammoInMag = 5;
    }
}
