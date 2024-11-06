using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    private SpriteRenderer _image;
    private const float ANIMATION_TIME =  0.5f;

    private void Start() {
        _image = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
            CollectAnimation();
    }

    private void CollectAnimation(){
        GetComponent<Collider2D>().enabled = false;

        Vector3 startPoint = transform.position;
        Vector3 peakPoint = startPoint + new Vector3(3, 2, 0);   // pico da parábola
        Vector3 endPoint = startPoint + new Vector3(5, -3, 0);    // ponto final

        Vector3[] path = new Vector3[] {startPoint, peakPoint, endPoint};
        
        Sequence animation = DOTween.Sequence();
        
        animation.Insert(0, transform.DOPath(path, ANIMATION_TIME, PathType.CatmullRom)
            .SetEase(Ease.OutSine)
        );
        animation.Insert(0, transform.DOScale(0f, ANIMATION_TIME)
            .SetEase(Ease.OutSine)
        );
        animation.Insert(0, _image.DOFade(0f, ANIMATION_TIME)
            .SetEase(Ease.OutSine)
        );

        animation.OnComplete(() => {
            Destroy(gameObject);
        });
    }
}
