using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragPoint : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IBeginDragHandler
{
    RectTransform pointRectTransform;
    Canvas canvas;
    bool isDragged = false;

    private void Start()
    {
        pointRectTransform = transform.GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        pointRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragged = true;
        GetComponentInChildren<Image>().raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragged = false;
        GetComponentInChildren<Image>().raycastTarget = true;
    }

    public bool IsDragged()
    {
        return isDragged;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointRectTransform.parent.SetAsLastSibling();
    }

    
}
