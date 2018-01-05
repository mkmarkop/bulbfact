using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public string password;

    private ChargeableObject _charge;
    private bool _displayOn;

	void Start () {
        _charge = GetComponent<ChargeableObject>();
        _displayOn = false;
	}
	
	void Update () {
		if(!_displayOn)
        {
            if(_charge.isCharged())
            {
                displayPassword();
            }
        }
	}

    private void displayPassword()
    {

    }
}
