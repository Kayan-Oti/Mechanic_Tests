using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_TopDown : MonoBehaviour
{
    [SerializeField] private float _moveSpeed  = 5f;
    private Vector2 _movement;
    private Rigidbody2D _rigidbody;
    private bool _canMove = true;
    private Interactor _interactor;

    //Animation
    private Animator _animator;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string LASTHORIZONTAL = "LastHorizontal";
    private const string LASTVERTICAL = "LastVertical";


    private void Awake(){
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _interactor = GetComponentInChildren<Interactor>();
    }

    private void OnEnable() {
        Manager_Event.DialogueManager.OnStartDialogue.Get().AddListener(DisableMovement);
        Manager_Event.DialogueManager.OnEndDialogue.Get().AddListener(EnableMovement);
    }

    private void OnDisable() {
        Manager_Event.DialogueManager.OnStartDialogue.Get().RemoveListener(DisableMovement);
        Manager_Event.DialogueManager.OnEndDialogue.Get().RemoveListener(EnableMovement);
    }

    private void Update(){
        //Movement
        if(_canMove)
            _movement = PlayerInputManager_TopDown.MOVEMENT;
        else
            _movement = Vector2.zero;
        
        _rigidbody.velocity = _movement * _moveSpeed;

        //Animation
        _animator.SetFloat(HORIZONTAL, _movement.x);
        _animator.SetFloat(VERTICAL, _movement.y);

        if(_movement != Vector2.zero){
            _animator.SetFloat(LASTHORIZONTAL, _movement.x);
            _animator.SetFloat(LASTVERTICAL, _movement.y);
        }
    }

    private void DisableMovement(){
        _canMove = false;
        _interactor.SetInteractState(false);
    }
    private void EnableMovement(){
        _canMove = true;
        _interactor.SetInteractState(true);
    }
}
