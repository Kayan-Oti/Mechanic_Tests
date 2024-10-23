using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


public class InputMangerUI : MonoBehaviour
{
    private GameObject _currentSelected;
    private MainInputSystem _inputActions;

    private void Awake(){
        _inputActions = new MainInputSystem();
        _inputActions.UI.Navigate.performed += CheckSelectedUI;
    }

    private void OnEnable() {
        _inputActions.UI.Enable();

        Manager_Event.GameManager.OnChangeCurrentSelectedUI.Get().AddListener(ChangeCurrentSelectedUI);
    }

    private void OnDisable() {
        _inputActions.UI.Disable();

        Manager_Event.GameManager.OnChangeCurrentSelectedUI.Get().RemoveListener(ChangeCurrentSelectedUI);
    }

    private void ChangeCurrentSelectedUI(GameObject current){
        _currentSelected = current;
    }

    private void CheckSelectedUI(InputAction.CallbackContext context){
        if(EventSystem.current.currentSelectedGameObject == null){
            EventSystem.current.SetSelectedGameObject(_currentSelected);
        }
    }
}
