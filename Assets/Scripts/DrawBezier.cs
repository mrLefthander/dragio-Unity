using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBezier : MonoBehaviour
{
    [SerializeField] GameObject linePoint1, linePoint2, linePoint3;
    RectTransform poin1RectTransform, poin2RectTransform, poin3RectTransform;
    LineRenderer lineRenderer;
    DragPoint[] dragPoints;
    private int numPoints = 100;
    void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
        lineRenderer.positionCount = numPoints;
        lineRenderer.useWorldSpace = true;

        poin1RectTransform = linePoint1.GetComponent<RectTransform>();
        poin2RectTransform = linePoint2.GetComponent<RectTransform>();
        poin3RectTransform = linePoint3.GetComponent<RectTransform>();
        DrawCurve();

        dragPoints = GetComponentsInChildren<DragPoint>();
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
        for (int i = 0; i < numPoints; i++)
        {
            float t = i / (float)numPoints;
            curvePoints[i] = CalculateCurvePoints(t, poin1RectTransform.position, poin2RectTransform.position, poin3RectTransform.position);
        }
        lineRenderer.SetPositions(curvePoints);
        lineRenderer.SetPosition(99, poin3RectTransform.position);
    }

    private Vector3 CalculateCurvePoints(float t, Vector3 position1, Vector3 position2, Vector3 position3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        return uu * position1 + 2 * u * t * position2 + tt * position3;
    }
}
