using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager_TopDown : MonoBehaviour
{
    [SerializeField] private Interactor _playerInteractor;
    public static Vector2 MOVEMENT;
    private MainInputSystem playerInputActions;

    private void Awake(){
        playerInputActions = new MainInputSystem();
        playerInputActions.Player.Interact.performed += Interact;
    }

    private void OnEnable(){
        playerInputActions.Player.Enable();
    }

    private void OnDisable(){
        playerInputActions.Player.Disable();
    }

    private void Update(){
        MOVEMENT = playerInputActions.Player.Movement.ReadValue<Vector2>();
    }

    private void Interact(InputAction.CallbackContext context){
        _playerInteractor.TryInteract();
    }

}
