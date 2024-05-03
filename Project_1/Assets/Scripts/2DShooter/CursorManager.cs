using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D crosshairTexture;

    private Vector2 _crosshairHotSpot;

    public void SetGameCursor()
    {
        _crosshairHotSpot = new Vector2(crosshairTexture.width / 2, crosshairTexture.height / 2);
        Cursor.SetCursor(crosshairTexture, _crosshairHotSpot, CursorMode.Auto);
    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
