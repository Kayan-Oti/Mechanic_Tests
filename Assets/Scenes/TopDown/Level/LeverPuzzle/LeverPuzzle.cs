using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : Abstract_Interactable
{
    [SerializeField] private GameObject _puzzleObject;
    [SerializeField] private TransitionController _controller;

    protected override void Start()
    {
        base.Start();
        _puzzleObject.SetActive(false);
    }

    protected override void InteractionAction()
    {
        Manager_Event.InteractionManager.OnStartInteraction.Get().Invoke();
        AnimationTransition(true);
    }

    public void ExitLeverPuzzle(){
        AnimationTransition(
            false,
            () => Manager_Event.InteractionManager.OnEndInteraction.Get().Invoke()
        );
    }

    public void AnimationTransition(bool puzzleActive, Action doLast = null){
        _controller.FadeIn(()  => {
            _puzzleObject.SetActive(puzzleActive);
            _controller.FadeOut(doLast);
        });
    }
}
