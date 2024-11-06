using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnterArea : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _fadeTargets;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
            OnEntherHouse();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player"))
            OnExitHouse();
    }

    private void OnEntherHouse(){
        foreach(SpriteRenderer sprite in _fadeTargets){
            DOTween.Complete(sprite);
            sprite.DOFade(0.3f, 0.25f);
        }
    }

    private void OnExitHouse(){
        foreach(SpriteRenderer sprite in _fadeTargets){
            DOTween.Complete(sprite);
            sprite.DOFade(1f, 0.25f);
        }
    }
}