using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour {

    [HideInInspector] public GameObject currentlySelectedCharacter;

    public void SelectCharacter(GameObject charToSelect) {
        currentlySelectedCharacter = charToSelect;
    }

    public void DeselectCharacter() {
        currentlySelectedCharacter.GetComponent<MovePlayer>().DeselectCharacter();
        currentlySelectedCharacter = null;
    }

}
