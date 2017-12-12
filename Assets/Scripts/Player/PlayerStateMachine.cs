using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerStateMachine : MonoBehaviour {

	public delegate void playerStateHandler(PlayerState newState);
	public static event playerStateHandler onStateChange;

	public float playerWalkSpeed = 1.0f;

	private Vector3 playerForward;
	private Animator playerAnimator;
	private PlayerState currentState;

	// Use this for initialization
	void Start () {
		playerForward = transform.forward;
		playerAnimator = GetComponent<Animator> ();
		currentState = PlayerState.idle;
	}
	
	// Update is called once per frame
	void Update () {
		onStateCycle ();
	}

	bool isValidTransition(PlayerState newState) {
		bool isValid = false;

		switch (currentState) {
		case PlayerState.idle:
			isValid = true;
			break;

		case PlayerState.walkingLeft:
			isValid = true;
			break;

		case PlayerState.walkingRight:
			isValid = true;
			break;

		case PlayerState.walkingForward:
			isValid = true;
			break;

		case PlayerState.walkingBackward:
			isValid = true;
			break;

		default:
			break;
		}

		return isValid;
	}

	void onStateCycle() {
		switch (currentState) {
		case PlayerState.idle:
			break;

		case PlayerState.walkingLeft:
			break;

		case PlayerState.walkingRight:
			break;

		case PlayerState.walkingForward:
			transform.Translate(
				new Vector3((playerWalkSpeed * -1.0f) * Time.deltaTime, 0f, 0f)
			);
			break;

		case PlayerState.walkingBackward:
			transform.Translate (
				new Vector3 ((playerWalkSpeed * 1.0f) * Time.deltaTime, 0f, 0f)
			);
			break;

		default:
			break;
		}
	}

	public void tryStateChange(PlayerState newState) {
		if (currentState == newState)
			return;

		if (!isValidTransition (newState))
			return;

		switch (newState) {
		case PlayerState.idle:
			playerAnimator.SetBool ("walking", false);
			break;

		case PlayerState.walkingLeft:
			playerAnimator.SetBool ("walking", true);
			// TO-DO
			break;

		case PlayerState.walkingRight:
			playerAnimator.SetBool ("walking", true);
			// TO-DO
			break;

		case PlayerState.walkingForward:
			playerAnimator.SetBool ("walking", true);
			transform.rotation = Quaternion.AngleAxis (0, Vector3.up);
			transform.forward = playerForward;
			break;

		case PlayerState.walkingBackward:
			playerAnimator.SetBool ("walking", true);
			transform.rotation = Quaternion.AngleAxis (-180, Vector3.up);
			transform.forward = playerForward;
			break;

		default:
			break;
		}

		currentState = newState;
		if (onStateChange != null) {
			onStateChange (currentState);
		}
	}
}
