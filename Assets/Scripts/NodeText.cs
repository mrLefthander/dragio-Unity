using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NodeText : MonoBehaviour, IPointerClickHandler
{
    InputField nodeInputField;
    Text nodeText;

    void Start()
    {
        nodeInputField = GetComponentInChildren<InputField>();
        nodeText = nodeInputField.GetComponentInChildren<Text>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.clickCount == 2)
        {
            ActivateField();
            nodeInputField.onEndEdit.AddListener(delegate { DeactivateField(); });
        }
    }

    private void ActivateField()
    {
        nodeText.raycastTarget = true;
        nodeInputField.ActivateInputField();
    }

    private void DeactivateField()
    {
        nodeText.raycastTarget = false;
        nodeInputField.DeactivateInputField();
    }
}
