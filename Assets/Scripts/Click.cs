using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Click : MonoBehaviour {

    [SerializeField]
    private LayerMask clickableLayer;

    private List<ClickOn> selectedObjects;

    void Start()
    {
        selectedObjects = new List<ClickOn>();
    }

    // Update is called once per frame
    void Update()
    {
	RaycastHit rayHit;
	// rightclick
        if(Input.GetMouseButtonUp(1))
        {
	    // get clicked point in the world
	    Physics.Raycast(
		Camera.main.ScreenPointToRay(Input.mousePosition),
		out rayHit
	    );

	    // find closest point on nav mesh within 5u
	    NavMeshHit navHit;
	    var found = NavMesh.SamplePosition(
		rayHit.point,
		out navHit,
		5f,
		NavMesh.AllAreas
	    );

	    if (!found)
	    {
		Debug.LogError("couldn't find suitable point");
		return;
	    }
	    // move selected agents to point and reset selection
            if (selectedObjects.Count > 0)
            {
                foreach (var obj in selectedObjects)
                {
                    obj.selected = false;
		    obj.SetDestination(navHit.position);
                }

                selectedObjects.Clear();
            }
        }
	// left click
        else if(Input.GetMouseButtonDown(0))
        {
	    // find clicked object
	    var found = Physics.Raycast(
		Camera.main.ScreenPointToRay(Input.mousePosition),
		out rayHit,
		clickableLayer
	    );

	    if (!found) return;
	    ClickOn clickOnScript = rayHit.collider.gameObject.GetComponent<ClickOn>();
	    if (clickOnScript == null) return;

	    // toggle the clicked object
	    if (!clickOnScript.selected)
	    {
		selectedObjects.Add(clickOnScript);
	    }
	    else
	    {
		selectedObjects.Remove(clickOnScript);
	    }
	    clickOnScript.selected = !clickOnScript.selected;
	}
    }
}
