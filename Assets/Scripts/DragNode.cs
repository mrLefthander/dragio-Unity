using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNode: MonoBehaviour, IDragHandler
{
    GameObject resizePoint;
    RectTransform nodeRectTransform;
    Canvas canvas;

    private void Start()
    {
        nodeRectTransform = transform.GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        resizePoint = GetComponentInChildren<ResizeNode>().gameObject;
        resizePoint.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        nodeRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }



}
