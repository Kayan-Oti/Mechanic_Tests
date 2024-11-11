using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager_TopDown : MonoBehaviour
{
    [SerializeField] private Interactor _playerInteractor;
    private MainInputSystem playerInputActions;
    public static Vector2 MOVEMENT;
    public static bool INTERACT;

    private void Awake(){
        playerInputActions = InputManager.playerInputActions;
    }

    private void OnEnable(){
        EnableInput();
        Manager_Event.InteractionManager.OnStartInteraction.Get().AddListener(DisableInput);
        Manager_Event.InteractionManager.OnEndInteraction.Get().AddListener(EnableInput);
    }

    private void OnDisable(){
        DisableInput();
        Manager_Event.InteractionManager.OnStartInteraction.Get().RemoveListener(DisableInput);
        Manager_Event.InteractionManager.OnEndInteraction.Get().RemoveListener(EnableInput);
    }

    private void Update(){
        //Movement
        MOVEMENT = playerInputActions.Player.Movement.ReadValue<Vector2>();

        //Interaction
        INTERACT = playerInputActions.Player.Interact.WasPressedThisFrame();
    }

    private void EnableInput(){
        playerInputActions.Player.Enable();
    }
    private void DisableInput(){
        playerInputActions.Player.Disable();
    }
}
