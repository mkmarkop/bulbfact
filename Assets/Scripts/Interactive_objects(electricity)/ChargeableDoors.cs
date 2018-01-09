using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeableDoors : ChargeableObject {
    private Animator _animator;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isCharged()) { executeAction(); }
	}

    public override void executeAction()
    {
        _animator.SetBool("open", true);
    }
}
