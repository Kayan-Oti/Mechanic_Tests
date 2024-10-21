using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour, IInteractable
{
    [SerializeField] private Manager_Dialogue _manager;
    [SerializeField] private SO_Dialogue _soDialogue;

    public void Interact()
    {
        _manager.StartDialogue(_soDialogue);
    }
}
