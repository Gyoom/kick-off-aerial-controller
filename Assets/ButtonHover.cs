using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float sizeMultiplier = 1.25f;
    [SerializeField] private float duration = 1.25f;
    [SerializeField] private AnimationCurve curve;
    
    private Vector2 _baseScale;

    private void Start()
    {
        _baseScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(_baseScale * sizeMultiplier, duration).SetEase(curve);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(_baseScale, duration / 2f).SetEase(curve);
    }
}
