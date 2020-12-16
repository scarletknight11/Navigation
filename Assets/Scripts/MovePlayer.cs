using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovePlayer : MonoBehaviour {

    private NavMeshAgent myNavMeshAgent;
    private SelectionController mySelectionController;

    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private bool isSelected = false;

    // Start is called before the first frame update
    void Start() {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        mySelectionController = FindObjectOfType<SelectionController>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(1) && isSelected) {
            ClickToMove();
        }
    }

    private void ClickToMove() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
         if (hasHit) {
              SetDestination(hit.point);
              isSelected = false;
         }
    }

    private void SetDestination(Vector3 target) {
            myNavMeshAgent.SetDestination(target);
            GetComponent<Renderer>().material = defaultMaterial;
    }

    private void OnMouseDown() {
        //If the character is clicked with left mouse button
        if (mySelectionController.currentlySelectedCharacter != gameObject && mySelectionController.currentlySelectedCharacter != null)
        {
            mySelectionController.DeselectCharacter();
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag)) {

                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null) {
                    selectionRenderer.material = highlightMaterial;
                }  
            }
        }
        isSelected = true;
        mySelectionController.SelectCharacter(gameObject);
    }

    public void DeselectCharacter() {
        isSelected = false;
        GetComponent<Renderer>().material = defaultMaterial;
    }
}
