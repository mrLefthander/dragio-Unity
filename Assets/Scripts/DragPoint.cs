using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPoint : MonoBehaviour, IDragHandler, IEndDragHandler
{
    RectTransform pointRectTransform;
    Canvas canvas;
    bool isDragged = false;

    private void Start()
    {
        pointRectTransform = transform.GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragged = true;
        pointRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragged = false;
    }

    public bool IsDragged()
    {
        return isDragged;
    }
}
