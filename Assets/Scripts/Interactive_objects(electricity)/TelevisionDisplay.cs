using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisionDisplay : ChargeableObject {

    public string password;

    private bool _displayOn;

	void Start () {
        base.Start();
        _displayOn = false;
	}
	
	void Update () {
        base.Update();

		if(!_displayOn)
        {
            if(isCharged())
            {
                executeAction();
            }
        }
	}

    //turn on display and show password
    override public void executeAction()
    {

    }
}
