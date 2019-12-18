using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] LayerMask selectableLayer;

    ClickOn currentlySelected;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Collider2D clickedCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), selectableLayer);

            if (clickedCollider != null)
            {
                ClickOn clicked = clickedCollider.gameObject.GetComponent<ClickOn>();
                if (currentlySelected != null)
                {
                    currentlySelected.Select(false);
                }
                clicked.Select(true);
                currentlySelected = clicked;
            }
        }
        if (Input.GetKeyDown(KeyCode.Delete) && currentlySelected != null)
        {
            currentlySelected.gameObject.SetActive(false);
            Destroy(currentlySelected.gameObject);
        }
    }
}
