using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set;}
    public static MainInputSystem playerInputActions;

    private void Awake(){
        if(Instance == null)
            Instance = this;

        playerInputActions = new MainInputSystem();
        playerInputActions.Commom.Enable();
    }
}
