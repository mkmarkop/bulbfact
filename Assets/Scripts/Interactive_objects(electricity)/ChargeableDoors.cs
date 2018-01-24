using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeableDoors : ChargeableObject {
    private Animator _animator;
    public Text displayRequiredCharge;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        _animator = GetComponent<Animator>();
        displayRequiredCharge.enabled = true;
        displayRequiredCharge.text = string.Format("{0}/{1}", _currentCharge, requiredCharge);
    }
	
	// Update is called once per frame
    protected override void Update () {
		if (isCharged()) { executeAction(); }
        if (!isCharged())
        {
            displayRequiredCharge.text = string.Format("{0}/{1}", _currentCharge, requiredCharge);
        }
        else
        {
            displayRequiredCharge.enabled = false;
        }
    }

    public override void executeAction()
    {
        _animator.SetBool("open", true);
    }
}
