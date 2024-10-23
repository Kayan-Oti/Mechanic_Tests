using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Button : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IDeselectHandler,ISubmitHandler
{

    protected virtual void OnClickEvent(){
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.ButtonClick, transform.position);
    }

    protected virtual void OnEnterEvent(){
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.ButtonHover, transform.position);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.selectedObject = gameObject;
    }

    public void OnSelect(BaseEventData eventData)
    {
        OnEnterEvent();
        Vector3 scale  = new Vector3(1.25f, 1.25f, 1);
        transform.DOScale(scale, 0.25f);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        transform.DOScale(Vector3.one, 0.25f);
    }

    public void OnSubmit(BaseEventData eventData)
    {
        OnClickEvent();
    }
}