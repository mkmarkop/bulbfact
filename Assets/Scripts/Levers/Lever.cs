﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable {

	public int leverValue;

	public delegate void toggleHandler(int valueChange);
	public static event toggleHandler onLeverToggle;

	private bool _turnedOn;

	private Animator _leverAnimator;

	protected override void Start () {
        base.Start();
		_turnedOn = false;

		_leverAnimator = GetComponent<Animator> ();
		_leverAnimator.SetBool ("TurnedOn", false);
	}
		
	public void toggleLever() {
		_turnedOn = !_turnedOn;
		 
		int valueChange;
		if (_turnedOn) {
			valueChange = leverValue;
			_leverAnimator.SetBool ("TurnedOn", true);
		} else {
			valueChange = -leverValue;
			_leverAnimator.SetBool ("TurnedOn", false);
		}

		// Is someone subscribed to lever toggling?
		if (onLeverToggle != null) {
			onLeverToggle (valueChange);
		}

	}

	public bool isTurnedOn() {
		return _turnedOn;
	}

	protected override void Interact ()
	{
		GetComponent<Lever> ().toggleLever ();
		setReuseable ();
	}
}
