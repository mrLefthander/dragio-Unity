using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOn : MonoBehaviour
{
    DragPoint[] dragPoints;
    ResizeNode[] resizeNodes;

    private void Start()
    {
        dragPoints = GetComponentsInChildren<DragPoint>(true);
        resizeNodes = GetComponentsInChildren<ResizeNode>(true);
    }

    public void Select(bool isSelecting)
    {
        if (resizeNodes.Length > 0)
        {
            foreach (ResizeNode resizeNode in resizeNodes)
            {
                resizeNode.gameObject.SetActive(isSelecting);
            }
        }
        else if (dragPoints.Length > 0)
        {
            foreach (DragPoint dragPoint in dragPoints)
            {
                dragPoint.gameObject.SetActive(isSelecting);
            }
        }
        
    }
}
