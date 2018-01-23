using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TelevisionDisplay : ChargeableObject {

    // The password to display once television is charged
    public string password;
    
    // The Canvas UI Text used to display the password
    public Text displayText;

	// The Canvas UI Text used to display the remaining required charge
	public Text displayRequiredCharge;

    private bool _displayOn;

    override
	protected void Start () {
        base.Start();
        _displayOn = false;
        displayText.enabled = false;
        displayText.text = password;

		displayRequiredCharge.enabled = true;
		displayRequiredCharge.text = string.Format("{0}/{1}", _currentCharge, requiredCharge);
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

		if (!isCharged()) {
			displayRequiredCharge.text = string.Format ("{0}/{1}", _currentCharge, requiredCharge);
		} else {
			displayRequiredCharge.enabled = false;
		}
	}

    //turn on display and show password
    override public void executeAction()
    {
        _displayOn = true;
        displayText.enabled = true;
    }
}
