using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStateMachine))]
public class PlayerController : MonoBehaviour {

	private PlayerStateMachine pMachine;
	// Use this for initialization
	void Start () {
		pMachine = GetComponent<PlayerStateMachine> ();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis ("Horizontal");
		if (horizontal == 0) {
			pMachine.tryStateChange (PlayerState.idle);
		} else if (horizontal < 0f) {
			pMachine.tryStateChange (PlayerState.walkingBackward);
		} else if (horizontal > 0f) {
			pMachine.tryStateChange (PlayerState.walkingForward);
		}
	}
}
