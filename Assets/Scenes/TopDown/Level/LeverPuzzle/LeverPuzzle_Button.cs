using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LeverPuzzle_Button : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private LeverPuzzle_Manager _puzzleManager;
    [SerializeField] private Image _lightButton;
    [SerializeField] private int _id;
    private bool _isPressed = false;

    private void Start(){
        _lightButton.color = Color.grey;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(_isPressed)
            return;
            
        _puzzleManager.OnClickButton(_id, this);
    }

    public void AnimationCorret(){
        _isPressed = true;
        _lightButton.color = Color.yellow;
    }

    public void AnimationMiss(){
        _isPressed = false;
        _lightButton.color = Color.grey;
        Sequence animation = DOTween.Sequence();
        animation.Append(_lightButton.DOColor(Color.red, 0.1f).SetLoops(3));
        animation.Append(_lightButton.DOColor(Color.grey, 0.1f));
    }

    public void AnimationComplete(){
        _lightButton.color = Color.grey;
        _lightButton.DOColor(Color.green, 0.20f).SetLoops(3);
    }
}
