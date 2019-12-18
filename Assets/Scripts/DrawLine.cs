using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] GameObject linePoint1, linePoint2;
    RectTransform poin1RectTransform, poin2RectTransform;
    LineRenderer lineRenderer;
    DragPoint[] dragPoints;
    EdgeCollider2D lineCollider;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;

        lineCollider = GetComponent<EdgeCollider2D>();

        poin1RectTransform = linePoint1.GetComponent<RectTransform>();
        poin2RectTransform = linePoint2.GetComponent<RectTransform>();
        Draw();

        dragPoints = GetComponentsInChildren<DragPoint>(true);

    }

    void Update()
    {
        foreach (DragPoint dragPoint in dragPoints)
        {
            if (dragPoint.IsDragged())
            {
                Draw();
            }
        }

    }

    private void Draw()
    {
        Vector2[] linePointsForCollider = new Vector2[2];
        linePointsForCollider[0] = poin1RectTransform.localPosition;
        linePointsForCollider[1] = poin2RectTransform.localPosition;

        lineCollider.points = linePointsForCollider;

        lineRenderer.SetPosition(0, poin1RectTransform.localPosition);
        lineRenderer.SetPosition(1, poin2RectTransform.localPosition);
    }
}
