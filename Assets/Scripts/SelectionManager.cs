using UnityEngine;

public class SelectionManager : MonoBehaviour  {

    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    // Update is called once per frame
    private void Update() {
        if (Input.GetMouseButtonDown(0))  {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {

                var selection = hit.transform;
                if (selection.CompareTag(selectableTag)) {

                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null) {
                        selectionRenderer.material = highlightMaterial;
                    }
                }    
            }
        }
    }
}
