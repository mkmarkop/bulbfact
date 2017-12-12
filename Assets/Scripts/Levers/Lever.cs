using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

	public int leverValue;

	public delegate void toggleHandler(int valueChange);
	public static event toggleHandler onLeverToggle;

	private bool turnedOn = false;


	void Start () {
	}
	
	void Update () {
	}
		
	public void toggleLever() {
		turnedOn = !turnedOn;
		 
		int valueChange;
		if (turnedOn) {
			valueChange = leverValue;
		} else {
			valueChange = -leverValue;
		}

		// Is someone subscribed to lever toggling?
		if (onLeverToggle != null) {
			onLeverToggle (valueChange);
		}

	}

	public bool isTurnedOn() {
		return turnedOn;
	}
		
}
