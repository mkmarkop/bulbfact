using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TelevisionDisplay : ChargeableObject {

    // The password to display once television is charged
    public string password;
    
    // The Canvas UI Text used to display the password
    public Text displayText;

    private bool _displayOn;

    override
	protected void Start () {
        base.Start();
        _displayOn = false;
        displayText.enabled = false;
        displayText.text = password;
    }
	
    override
	protected void Update () {
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
        _displayOn = true;
        displayText.enabled = true;
    }
}
