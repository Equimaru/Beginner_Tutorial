using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOverPanel : MonoBehaviour
{
    void Start()
    {
        GetComponent<RectTransform>().DOAnchorPos(new Vector2(0f,0f), 1f);
    }

}
