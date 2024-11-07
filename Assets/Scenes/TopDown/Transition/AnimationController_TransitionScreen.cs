using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MyBox;
using UnityEngine;

public class AnimationController_TransitionScreen : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    private Vector2 _finalSize;

    private void Start() {
        _rectTransform = GetComponent<RectTransform>();

        Debug.Log(Screen.width + " " + Screen.height);
        float size = 1920 * 1.2f;
        _finalSize = new Vector2(size, size);
        Debug.Log(_finalSize);

        _rectTransform.sizeDelta = _finalSize;
    }

    [ButtonMethod]
    public void FadeInAnimation(){
        _rectTransform.DOSizeDelta(Vector2.zero, 1.0f);
    }

    [ButtonMethod]
    public void FadeOutAnimation(){
        _rectTransform.DOSizeDelta(_finalSize, 1.0f);
    }
}
