using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawBezier : MonoBehaviour
{
    [SerializeField] GameObject linePoint1, linePoint2, linePoint3;
    RectTransform poin1RectTransform, poin2RectTransform, poin3RectTransform;
    LineRenderer lineRenderer;
    DragPoint[] dragPoints;
    EdgeCollider2D curveCollider;

    private int numPoints = 100;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numPoints;
        lineRenderer.useWorldSpace = false;

        curveCollider = GetComponent<EdgeCollider2D>();

        poin1RectTransform = linePoint1.GetComponent<RectTransform>();
        poin2RectTransform = linePoint2.GetComponent<RectTransform>();
        poin3RectTransform = linePoint3.GetComponent<RectTransform>();
        DrawCurve();

        dragPoints = GetComponentsInChildren<DragPoint>(true);
    }
       
    void Update()
    {
        foreach(DragPoint dragPoint in dragPoints)
        {
            if (dragPoint.IsDragged())
            {
                DrawCurve();
            }
        }
    }

    public void DrawCurve()
    {
        Vector3[] curvePoints = new Vector3[numPoints];
        Vector2[] curvePointsForCollider = new Vector2[numPoints];
        for (int i = 0; i < numPoints; i++)
        {
            float t = i / (float)numPoints;
            curvePoints[i] = CalculateCurvePoint(t, poin1RectTransform.localPosition, poin2RectTransform.localPosition, poin3RectTransform.localPosition);

            curvePointsForCollider[i] = curvePoints[i];
        }
        lineRenderer.SetPositions(curvePoints);
        lineRenderer.SetPosition(99, poin3RectTransform.localPosition);
        curveCollider.points = curvePointsForCollider;
    }

    private Vector3 CalculateCurvePoint(float t, Vector3 position1, Vector3 position2, Vector3 position3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        return uu * position1 + 2 * u * t * position2 + tt * position3;
    }
}
