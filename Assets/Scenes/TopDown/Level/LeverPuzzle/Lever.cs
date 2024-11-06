using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Abstract_Interactable
{
    [SerializeField] private GameObject _puzzleObject;

    protected override void Start()
    {
        base.Start();
        _puzzleObject.SetActive(false);
    }

    protected override void InteractionAction()
    {
        _puzzleObject.SetActive(true);
    }

    public void ExitLeverPuzzle(){
        _puzzleObject.SetActive(false);
    }
}
