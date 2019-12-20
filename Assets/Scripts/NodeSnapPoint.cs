using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeSnapPoint : MonoBehaviour, IDropHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            eventData.pointerDrag.transform.parent.SetParent(gameObject.transform.parent);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
            eventData.pointerDrag.transform.parent.SetParent(GetComponentInParent<Canvas>().transform);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
