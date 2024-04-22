using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D crosshairTexture;

    private Vector2 _crosshairHotSpot;

    private void Start()
    {
        _crosshairHotSpot = new Vector2(crosshairTexture.width / 2, crosshairTexture.height / 2);
        Cursor.SetCursor(crosshairTexture, _crosshairHotSpot, CursorMode.Auto);
    }

}
