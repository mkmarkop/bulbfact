using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSystem : MonoBehaviour {

	public int targetLeverValue;

	private int _currentLeverValue;
	public bool _systemEnabled;

	// public LeverSystemListener listener

	void myOnLeverToggle(int valueChange) {
		_currentLeverValue += valueChange;

		if (_currentLeverValue == targetLeverValue) {
			_systemEnabled = true;
			// listener.activate()
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

	public bool isSystemEnabled() {
		return _systemEnabled;
	}
		
}
