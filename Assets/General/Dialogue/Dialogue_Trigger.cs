using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour, IInteractable
{
    [SerializeField] private Manager_Dialogue _manager;
    [SerializeField] private SO_Dialogue _soDialogue;
    [SerializeField] private GameObject _interactionText;
    private bool _canInteract = true;

    public void Start(){
        _interactionText.SetActive(false);
    }

    public void Interact(Interactor interactor)
    {
        if(!CanInteract())
            return;

        _canInteract = false;
        SetInteractionText(false);
        _manager.StartDialogue(_soDialogue);
    }

    public bool CanInteract(){
        return _canInteract;
    }

    public void SetIsInRange(bool state){
        if(!CanInteract())
            return;

        SetInteractionText(state);
    }

    private void SetInteractionText(bool state){
        _interactionText.SetActive(state);
    }
}
