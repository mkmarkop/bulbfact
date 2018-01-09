using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour {
    private GameObject _player;
    private float _chargeSpeed;
    private PlayerCharge _playerCharge;
    private PlayerStateMachine _playerStateMachine;

    // Use this for initialization
    void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
        _chargeSpeed = 5f;
        _playerCharge = _player.GetComponent<PlayerCharge>();
        _playerStateMachine = _player.GetComponent<PlayerStateMachine>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("StandingTrigger")) { return; }
        if (Input.GetButtonDown("Activate"))
        {
            _playerStateMachine.tryStateChange(PlayerState.charging);
        }
    }

    // Update is called once per frame
    void Update () {
        if (_playerStateMachine.GetCurrentState() == PlayerState.charging) { _playerCharge.Charge(_chargeSpeed); }	
	}
}