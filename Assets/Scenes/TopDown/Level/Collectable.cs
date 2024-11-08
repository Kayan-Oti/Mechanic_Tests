using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Abstract_Interactable
{
    [SerializeField] private  Manager_Collectables _manager;
    [SerializeField] public Sprite _spriteDisplay;
    private bool _hasBeenCollected =  false;

    protected override void InteractionAction()
    {
        _manager.OnCollect(this);
        _hasBeenCollected = true;
    }

    public void DisableCollectable(){
        transform.parent.gameObject.SetActive(false);
    }

    protected override bool HasMoreInteraction()
    {
        return !_hasBeenCollected;
    }
}
