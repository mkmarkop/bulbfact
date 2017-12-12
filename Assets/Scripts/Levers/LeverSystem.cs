using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSystem : MonoBehaviour {

	public int targetLeverValue;

	private int currentLeverValue;
	private bool systemEnabled;

	void myOnLeverToggle(int valueChange) {
		currentLeverValue += valueChange;

		if (currentLeverValue == targetLeverValue) {
			systemEnabled = true;
		} else {
			systemEnabled = false;
		}
	}

	void OnEnable() {
		Lever.onLeverToggle += myOnLeverToggle;
	}

	void OnDisable() {
		Lever.onLeverToggle -= myOnLeverToggle;
	}

	void Start () {
		int currentLeverValue = 0;
		systemEnabled = false;
	}
	
	void Update () {
		
	}
		
}
