using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager_TopDown : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    public static Vector2 MOVEMENT;

    private void Awake(){
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Movement"];
    }

    private void Update(){
        MOVEMENT = _moveAction.ReadValue<Vector2>();
    }

}
