using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform OrgParent;
    public GameObject PlaceHolder;

    public Transform PlaceHoldPos;

    public void Start()
    {
        OrgParent = null;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Grab");

        PlaceHolder = new GameObject();
        PlaceHolder.transform.SetParent(this.transform.parent);
        PlaceHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        if (this.transform.parent.GetComponent<DropZone>().IsDeckArea == true)
        {
            PlaceHoldPos = this.transform;
        }

        //Shows what is the selected card's sibling index
        Debug.Log(this.transform.GetSiblingIndex());
        Debug.Log(PlaceHolder.transform.GetSiblingIndex());

        OrgParent = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag");

        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("Drop");

        this.transform.SetParent(OrgParent);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if(this.transform.parent.GetComponent<DropZone>().IsDeckArea == true)
        {
            this.transform.SetSiblingIndex(PlaceHolder.transform.GetSiblingIndex());
        }

        Debug.Log(this.transform.GetSiblingIndex());

        Destroy(PlaceHolder);
        //Save Placeholder Data
    }
}
