using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : Abstract_Interactable
{
    [SerializeField] private GameObject _puzzleObject;
    [SerializeField] private TransitionController _controller;
    private bool _isPuzzleCompleted = false;

    protected override void Start()
    {
        base.Start();
        _puzzleObject.SetActive(false);
    }

    protected override void InteractionAction()
    {
        AnimationTransition(true);
    }
    protected override bool HasMoreInteraction()
    {
        return !_isPuzzleCompleted;
    }

    public void ExitLeverPuzzle(bool hasCompletedPuzzle){
        _isPuzzleCompleted = hasCompletedPuzzle;

        AnimationTransition(
            false,
            () => EndInteraction()
        );
    }

    public void AnimationTransition(bool puzzleActive, Action doLast = null){
        _controller.FadeIn(()  => {
            _puzzleObject.SetActive(puzzleActive);
            _controller.FadeOut(doLast);
        });
    }

}
