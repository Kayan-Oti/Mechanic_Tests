using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Abstract_Interactable
{
    [SerializeField] private  Manager_Collectables _manager;
    [SerializeField] public Sprite _spriteDisplay;

    protected override void InteractionAction()
    {
        _manager.OnCollect(this);
    }

    public void DisableCollectable(){
        transform.parent.gameObject.SetActive(false);
    }
}
