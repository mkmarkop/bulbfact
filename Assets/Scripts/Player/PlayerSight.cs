using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerSight : MonoBehaviour {

	public delegate void sightHandler (Interactable intObject);
	public static event sightHandler onFocused;

	void OnTriggerEnter(Collider other) {
		Interactable intObj = other.GetComponent<Interactable> ();
		if (intObj != null) {
            intObj.EnableHighlight();
            if (onFocused != null) {
                onFocused(intObj);
            }
		}
	}

	void OnTriggerExit(Collider other) {
		Interactable intObj = other.GetComponent<Interactable> ();
		if (intObj != null && onFocused != null) {
            intObj.DisableHighlight();
            if (onFocused != null) {
			    onFocused (null);
            }
		}
	}
}
