using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharge : MonoBehaviour {

    public Color MaxChargeColor = Color.green;
    public Color MinChargeColor = Color.red;
    public Slider chargeSlider;
    public Image Fill;  // assign in the editor the "Fill"

    public float _currentCharge;
    public static readonly float maxCharge = 2000.0f;

    // Use this for initialization
    void Start () {
        _currentCharge = 0.0f;
    }

	// Update is called once per frame
	void Update () {
        chargeSlider.value = _currentCharge;
        Fill.color = Color.Lerp(MinChargeColor, MaxChargeColor, (float) _currentCharge / maxCharge);
    }

    public void Charge(float receivedCharge) {
        _currentCharge += receivedCharge;
        if (_currentCharge > maxCharge) {
            _currentCharge = maxCharge;
        }
    }

    public float Discharge(float sentCharge) {
        float prev = _currentCharge;
        _currentCharge -= sentCharge;
        if (_currentCharge < 0.0f) {
            _currentCharge = 0;
        }

        return prev - _currentCharge;
    }

	public float getCurrentCharge() {
		return _currentCharge;
	}
}
