using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_TopDown : MonoBehaviour
{
    [SerializeField] private float _moveSpeed  = 5f;
    private Vector2 _movement;
    private Rigidbody2D _rigidbody;

    //Animation
    private Animator _animator;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string LASTHORIZONTAL = "LastHorizontal";
    private const string LASTVERTICAL = "LastVertical";

    private void Awake(){
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update(){
        //Movement
        _movement = PlayerInputManager_TopDown.MOVEMENT;
        _rigidbody.velocity = _movement * _moveSpeed;

        //Animation
        _animator.SetFloat(HORIZONTAL, _movement.x);
        _animator.SetFloat(VERTICAL, _movement.y);

        if(_movement != Vector2.zero){
            _animator.SetFloat(LASTHORIZONTAL, _movement.x);
            _animator.SetFloat(LASTVERTICAL, _movement.y);
        }
    }
}
