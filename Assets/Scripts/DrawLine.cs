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

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;

        poin1RectTransform = linePoint1.GetComponent<RectTransform>();
        poin2RectTransform = linePoint2.GetComponent<RectTransform>();
        Draw();

        dragPoints = GetComponentsInChildren<DragPoint>();
    }

    

    // Update is called once per frame
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
        lineRenderer.SetPosition(0, poin1RectTransform.position);
        lineRenderer.SetPosition(1, poin2RectTransform.position);
    }
}
