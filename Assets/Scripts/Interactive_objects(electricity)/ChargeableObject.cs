using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public float requiredCharge;

    private float _currentCharge;
    private float _maxCharge;
    private bool _objectCharged;
	
	void Start () {
        _currentCharge = 0.0f;
        _maxCharge = 2000.0f;
        _objectCharged = false;
	}
	
	void Update () {
		if(_currentCharge >= requiredCharge)
        {
            _objectCharged = true;
        }
	}

    public void charge(float receivedCharge)
    {
        _currentCharge += receivedCharge;

        if(_currentCharge < 0.0f)
        {
            _currentCharge = 0;
        } else if(_currentCharge > _maxCharge)
        {
            _currentCharge = _maxCharge;
        }
    }

    public bool isCharged()
    {
        return _objectCharged;
    }

}
