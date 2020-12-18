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
    private BrakeController brake;

    private bool _selected = false;
    public bool selected
    {
	set
	{
	    myRend.material = value ? highlightMaterial : defaultMaterial;
	    _selected = value;
	}
	get
	{
	    return _selected;
	}
    }

    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        mySelectionController = FindObjectOfType<SelectionController>();
        myRend = GetComponent<MeshRenderer>();
	brake = GetComponent<BrakeController>();
    }

    public void SetDestination(Vector3 target)
    {
	brake.Release();
        myNavMeshAgent.SetDestination(target);
    }

}
