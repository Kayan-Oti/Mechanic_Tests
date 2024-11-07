using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LeverPuzzle_Lever : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent _onActiveLever;
    private Image image;
    private bool _canComplete =  false;

    private void Start() {
        image = GetComponent<Image>();
    }

    public void ActiveComplete(){
        _canComplete = true;
        image.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!_canComplete)
            return;

        image.color = Color.green;
        _onActiveLever.Invoke();
    }
}
