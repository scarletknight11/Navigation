using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickOn : MonoBehaviour {

    [SerializeField]
    private Material highlightMaterial;
    [SerializeField]
    private Material defaultMaterial;

    private MeshRenderer myRend;

    private NavMeshAgent myNavMeshAgent;
    private SelectionController mySelectionController;


    [HideInInspector]
    public bool currentlySelected = false;

    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        mySelectionController = FindObjectOfType<SelectionController>();
        myRend = GetComponent<MeshRenderer>();
        ClickMe();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentlySelected)
        {
            ClickToMove();
        }
    }

    public void ClickMe()
    {
        if(currentlySelected == false)
        {
            myRend.material = highlightMaterial;
        } else
        {
            myRend.material = defaultMaterial;
        }
    }

    private void ClickToMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            SetDestination(hit.point);
            //isSelected = false;
        }
    }

    private void SetDestination(Vector3 target)
    {
        myNavMeshAgent.SetDestination(target);
        GetComponent<Renderer>().material = defaultMaterial;
    }

}
