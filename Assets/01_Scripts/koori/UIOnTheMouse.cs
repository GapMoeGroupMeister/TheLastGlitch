using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIOnTheMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 _originalScale;
    private RectTransform _scale;

    private void Start()
    {
        _scale = GetComponent<RectTransform>();
        _originalScale = _scale.localScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _scale.DOScale(_originalScale, 0.5f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _scale.DOScale(new Vector3(1.3f, 1.3f, 1), 0.5f);
    }
}
