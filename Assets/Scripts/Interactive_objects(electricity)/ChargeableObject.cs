using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChargeableObject : MonoBehaviour {

    public float requiredCharge;

    protected float _currentCharge;
    private static readonly float _maxCharge = 2000.0f;
	
	protected virtual void Start () {
        _currentCharge = 0.0f;
	}
	
	protected virtual void Update () {

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
        return _currentCharge >= requiredCharge;
    }

    public abstract void executeAction();
}
