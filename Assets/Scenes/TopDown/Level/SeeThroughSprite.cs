using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SeeThroughSprite : MonoBehaviour
{
    private SpriteRenderer _fadeTarget;

    private void Start()
    {
        _fadeTarget = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            DOTween.Complete(_fadeTarget);
            _fadeTarget.DOFade(0.3f, 0.25f);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            DOTween.Complete(_fadeTarget);
            _fadeTarget.DOFade(1f, 0.25f);
        }
    }
}
