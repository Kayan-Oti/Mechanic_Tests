using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Abstract_Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] protected GameObject _interactionText;
    protected bool _canInteract = true;
    [SerializeField] protected bool _loop = false;

    protected virtual void Start(){
        _interactionText.SetActive(false);
    }

    public void Interact(Interactor interactor)
    {
        if(!CanInteract())
            return;

        _canInteract = _loop;
        SetInteractionText(_loop);

        InteractionAction();
    }

    public virtual bool CanInteract(){
        return _canInteract;
    }

    public virtual void SetIsInRange(bool state){
        if(!CanInteract())
            return;

        SetInteractionText(state);
    }

    private void SetInteractionText(bool state){
        _interactionText.SetActive(state);
    }

    protected abstract void InteractionAction();
}
