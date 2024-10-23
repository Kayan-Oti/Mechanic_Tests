using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact(Interactor interactor);
    public bool CanInteract();
    public void SetIsInRange(bool state);
}
