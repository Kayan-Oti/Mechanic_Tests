using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderVolumeSelect : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private UI_SliderVolume _container;

    private void Start(){
        _container = GetComponentInParent<UI_SliderVolume>();
    }
    public void OnSelect(BaseEventData eventData)
    {
        _container.OnSelect();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        _container.OnDeselect();
    }
}
