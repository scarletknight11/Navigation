using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MySelectable : MonoBehaviour, ISelectHandler, IPointerClickHandler, IDeselectHandler{

    public static HashSet<MySelectable> allMySelectable = new HashSet<MySelectable>();
    public static HashSet<MySelectable> currentlySelected = new HashSet<MySelectable>();

    Renderer myRenderer;

    [SerializeField]
    Material unselectedMaterial;
    [SerializeField]
    Material selectedMaterial;

    void Awake()
    {
        //add selected object to list of storage
        allMySelectable.Add(this);
        myRenderer = GetComponent<Renderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSelect(eventData);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if(!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
        {
            DeselectAll(eventData);
        }
        currentlySelected.Add(this);
        myRenderer.material = selectedMaterial;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        myRenderer.material = unselectedMaterial;
    }

    private void DeselectAll(BaseEventData eventData)
    {
        //for each object already selected check off ones you wanna deselect
        foreach(MySelectable selectable in currentlySelected)
        {
            //select objects you want to deselect
            selectable.OnDeselect(eventData);
        }
        //clear deselection
        currentlySelected.Clear();
    }
}
