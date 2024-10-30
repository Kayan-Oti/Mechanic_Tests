using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float _translationY;
    [SerializeField] private float _maximumScale = 1.3f;
    [SerializeField] private float _duration = 0.5f;
    private Vector3 _positionStart;
    private Sequence _animation;

    private void InitSetup(){
        _positionStart = transform.position;
        _animation?.Kill(true);
        _animation = DOTween.Sequence();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InitSetup();
        _animation.Insert(0, _rectTransform.DOMoveY(_positionStart.y+_translationY, _duration)
            .SetEase(Ease.InSine));
        _animation.Insert(0, SquashAndStretch(1.0f, _maximumScale));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InitSetup();
        _animation.Insert(0, _rectTransform.DOMoveY(_positionStart.y, _duration/2)
            .SetEase(Ease.OutSine));
    }

    private Tween SquashAndStretch(float baseScale, float maxScale){
        float minScale = maxScale - baseScale;

        Sequence sequence = DOTween.Sequence();

        // Fase de Stretch
        sequence.Append(_rectTransform.DOScale(new Vector3(minScale, maxScale, 1f), _duration).SetEase(Ease.OutQuad).OnComplete(SetPivotToTopCenter));
        
        // Fase de Squash
        sequence.Append(_rectTransform.DOScale(new Vector3(maxScale, minScale, 1f), _duration).SetEase(Ease.OutQuad));

        // Retornar ao tamanho original
        sequence.Append(_rectTransform.DOScale(Vector3.one, _duration).SetEase(Ease.OutQuad).OnComplete(ResetPivotToCenter));

        return sequence;
    }

    // Método para mudar o pivot e manter a posição visual
    public void SetPivotWithPosition(Vector2 newPivot)
    {
        // Calcula a diferença de posição ao mudar o pivot
        Vector2 deltaPosition = _rectTransform.pivot - newPivot;
        Vector2 size = _rectTransform.rect.size;
        Vector3 worldDelta = new Vector3(deltaPosition.x * size.x * _rectTransform.localScale.x, 
                                         deltaPosition.y * size.y * _rectTransform.localScale.y);

        // Ajusta a posição do RectTransform
        _rectTransform.pivot = newPivot;
        _rectTransform.localPosition -= worldDelta;
    }

    // Método específico para definir o pivot no topo central e manter a posição
    public void SetPivotToTopCenter()
    {
        SetPivotWithPosition(new Vector2(0.5f, 1f));
    }

    // Método para resetar o pivot ao centro e manter a posição
    public void ResetPivotToCenter()
    {
        SetPivotWithPosition(new Vector2(0.5f, 0.5f));
    }
}