using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolOfWater : MonoBehaviour {

	public GameObject player;
	public Vector3 repositionLocation;

	private PlayerStateMachine _playerStateMachine;
	private float _initialWalkSpeed;
	private PlayerCharge _playerCharge;

	private bool _playerStunned;
	private float _startTime;

	void Start () {
		_playerStateMachine = player.GetComponent<PlayerStateMachine> ();
		_initialWalkSpeed = _playerStateMachine.playerWalkSpeed;
		_playerCharge = player.GetComponent<PlayerCharge> ();

		_playerStunned = false;
	}

	void Update () {
		if (_playerStunned) {
			if (Time.time <= _startTime + 3.0f) {
				//what to do to the player while he is stunned
				_playerStateMachine.tryStateChange (PlayerState.idle);
				_playerStateMachine.playerWalkSpeed = 0.0f;
			} else {
				_playerStunned = false;
				_playerStateMachine.playerWalkSpeed = _initialWalkSpeed;
				repositionPlayer ();
			}
		}
	}

	// requires that he Collider of the object using this script has Is Trigger set to true;
	void OnTriggerEnter(Collider other) {
		if (_playerCharge.getCurrentCharge() > 0.0f) {
			if (other.gameObject == player && _playerStunned == false) {
				_playerCharge.Discharge (PlayerCharge.maxCharge);

				_playerStunned = true;
				_startTime = Time.time;
			}
		}
	}

	private void repositionPlayer() {
		player.transform.localPosition = repositionLocation;
	}
}
