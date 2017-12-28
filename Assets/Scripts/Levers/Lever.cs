using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

	public int leverValue;

	public delegate void toggleHandler(int valueChange);
	public static event toggleHandler onLeverToggle;

	private bool _turnedOn;


	void Start () {
		_turnedOn = flase;
	}
	
	void Update () {
	}
		
	public void toggleLever() {
		_turnedOn = !_turnedOn;
		 
		int valueChange;
		if (_turnedOn) {
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
		return _turnedOn;
	}
		
}
