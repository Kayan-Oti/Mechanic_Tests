using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotationAnimation : MonoBehaviour
{
    private Vector3 _rotation = new Vector3(0, 360, 0);
    private float _duration = 2f;

    void Start()
    {
        transform.DORotate(_rotation, _duration, RotateMode.FastBeyond360)
                 .SetEase(Ease.Linear)
                 .SetLoops(-1, LoopType.Restart);
    }
}
