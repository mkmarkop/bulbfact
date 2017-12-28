using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSystem : MonoBehaviour {

	public int targetLeverValue;

	private int _currentLeverValue;
	private bool _systemEnabled;

	void myOnLeverToggle(int valueChange) {
		_currentLeverValue += valueChange;

		if (_currentLeverValue == targetLeverValue) {
			_systemEnabled = true;
		} else {
			_systemEnabled = false;
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
		_systemEnabled = false;
	}
	
	void Update () {
		
	}
		
}
