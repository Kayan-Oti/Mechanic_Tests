using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle_Manager : MonoBehaviour
{
    [SerializeField] private LeverPuzzle _lever;
    [SerializeField] private List<LeverPuzzle_Button> _buttons;
    [SerializeField] private LeverPuzzle_Lever _puzzleLever;
    private List<int> _correctSequence = new List<int> {1, 3, 2};
    private int _currentIndex = 0;
    public bool _isCompleted;

    private void Start() {
        GetComponentsInChildren(_buttons);
    }

    public void OnClickButton(int id, LeverPuzzle_Button button)
    {
        if(_isCompleted)
            return;

        if(_correctSequence[_currentIndex] != id){
            _currentIndex = 0;
            OnMissSequence();
            return;
        }
            
        _currentIndex++;
        if(_currentIndex == _correctSequence.Count)
            OnComplete();
        else
            button.AnimationCorret();

        return;
    }

    private void OnMissSequence(){
        foreach(LeverPuzzle_Button button in _buttons){
            button.AnimationMiss();
        }
    }

    private void OnComplete(){
        _isCompleted = true;
        foreach(LeverPuzzle_Button button in _buttons){
            button.AnimationComplete();
        }

        _puzzleLever.ActiveComplete();
    }

    public void OnActiveLever(){
        _lever.ExitLeverPuzzle(_isCompleted);
    }
}
