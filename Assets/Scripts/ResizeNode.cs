using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResizeNode: MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler
{
    [SerializeField] Vector2 minSize;
    [SerializeField] Vector2 maxSize;

    RectTransform nodeRectTransform;
    Vector2 currentPointerPosition;
    Vector2 previousPointerPosition;
    BoxCollider2D collider;

    void Start()
    {
        nodeRectTransform = transform.parent.GetComponent<RectTransform>();
        collider = transform.parent.GetComponent<BoxCollider2D>();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        nodeRectTransform.SetAsLastSibling();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(nodeRectTransform, eventData.position, eventData.pressEventCamera, out previousPointerPosition);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 sizeDelta = nodeRectTransform.sizeDelta;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(nodeRectTransform, eventData.position, eventData.pressEventCamera, out currentPointerPosition);
        Vector2 resizeValue = currentPointerPosition - previousPointerPosition;

        sizeDelta += new Vector2(resizeValue.x, -resizeValue.y);
        sizeDelta = new Vector2(
            Mathf.Clamp(sizeDelta.x, minSize.x, maxSize.x),
            Mathf.Clamp(sizeDelta.y, minSize.y, maxSize.y)
            );

        nodeRectTransform.sizeDelta = sizeDelta;

        previousPointerPosition = currentPointerPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        collider.size = nodeRectTransform.sizeDelta;
        collider.offset = new Vector2(nodeRectTransform.sizeDelta.x / 2, -nodeRectTransform.sizeDelta.y / 2);
    }
}