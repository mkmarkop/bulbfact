using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharge : MonoBehaviour {
    public float _currentCharge;
    private static readonly float _maxCharge = 2000.0f;

    // Use this for initialization
    void Start () {
        _currentCharge = 0.0f;
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void Charge(float receivedCharge) {
        _currentCharge += receivedCharge;
        if (_currentCharge > _maxCharge) {
            _currentCharge = _maxCharge;
        }
    }

    public void Discharge(float sentCharge) {
        _currentCharge -= sentCharge;
        if (_currentCharge < 0.0f) {
            _currentCharge = 0;
        }
    }
}
