using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Collectables : MonoBehaviour
{
    [SerializeField] private UI_ManagerAnimation _animator;
    [SerializeField] private GameObject _button;
    [SerializeField] private Image _imageDisplay;
    private Collectable _currentCollectable;

    private void Start() {
        _button.SetActive(false);
    }

    public void OnCollect(Collectable collectable){
        Manager_Event.InteractionManager.OnStartInteraction.Get().Invoke();
        _animator.PlayAnimation("Start", () => _button.SetActive(true));

        _currentCollectable = collectable;
        _imageDisplay.sprite = collectable._spriteDisplay;
    }

    public void OnEndCollect(){
        _button.SetActive(false);
        _animator.PlayAnimation("End", () => Manager_Event.InteractionManager.OnEndInteraction.Get().Invoke());

        _currentCollectable.DisableCollectable();
        _currentCollectable = null;
    }
}
