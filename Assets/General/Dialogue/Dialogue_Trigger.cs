using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : Abstract_Interactable
{
    [SerializeField] private Manager_Dialogue _manager;
    [SerializeField] private SO_Dialogue _soDialogue;

    protected override void InteractionAction()
    {
        _manager.StartDialogue(_soDialogue);
    }
}