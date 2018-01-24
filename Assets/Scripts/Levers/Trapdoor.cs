using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour {

	public GameObject leverSystemObject;

	private LeverSystem _leverSystem;
	private Animator _animator;
	private bool _doorOpened;

	// Use this for initialization
	void Start () {
		_leverSystem = leverSystemObject.GetComponent<LeverSystem> ();
		_animator = GetComponent<Animator> ();
		_doorOpened = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!_doorOpened) {
			if (_leverSystem.isSystemEnabled ()) {
				_doorOpened = true;
				_animator.SetBool ("DoorOpened", true);
			}
		} else {
			if(!_leverSystem.isSystemEnabled()) {
				_doorOpened = false;
				_animator.SetBool("DoorOpened", false);
			}
		}
	}
}
