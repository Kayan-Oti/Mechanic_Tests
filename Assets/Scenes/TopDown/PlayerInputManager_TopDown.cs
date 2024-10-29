using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager_TopDown : MonoBehaviour
{
    [SerializeField] private Interactor _playerInteractor;
    public static Vector2 MOVEMENT;
    private MainInputSystem playerInputActions;

    private void Awake(){
        playerInputActions = InputManager.playerInputActions;
    }

    private void OnEnable(){
        playerInputActions.Player.Enable();
            Manager_Event.DialogueManager.OnStartDialogue.Get().AddListener(DisableInteraction);
        Manager_Event.DialogueManager.OnEndDialogue.Get().AddListener(EnableInteraction);
    }

    private void OnDisable(){
        playerInputActions.Player.Disable();
        Manager_Event.DialogueManager.OnStartDialogue.Get().RemoveListener(DisableInteraction);
        Manager_Event.DialogueManager.OnEndDialogue.Get().RemoveListener(EnableInteraction);
    }

    private void Update(){
        //Movement
        MOVEMENT = playerInputActions.Player.Movement.ReadValue<Vector2>();

        //Interaction
        if(playerInputActions.Player.Interact.WasPerformedThisFrame())
            Interact();
    }

    private void Interact(){
        _playerInteractor.TryInteract();
    }

    private void DisableInteraction(){
        _playerInteractor.SetInteractState(false);
    }
    private void EnableInteraction(){
        _playerInteractor.SetInteractState(true);
    }
}
