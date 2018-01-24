using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discharger : MonoBehaviour {
    public ChargeableObject chargeableObject;
    private GameObject _player;
    private float _dischargeSpeed;
    private PlayerCharge _playerCharge;
    private PlayerStateMachine _playerStateMachine;

    // Use this for initialization
    void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
        _dischargeSpeed = 5f;
        _playerCharge = _player.GetComponent<PlayerCharge>();
        _playerStateMachine = _player.GetComponent<PlayerStateMachine>();

    }
    public void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) { return; }
        if (Input.GetButtonDown("Activate"))
        {
            _playerStateMachine.tryStateChange(PlayerState.discharging);
        }
    }
    // Update is called once per frame
    void Update () {
        if (_playerStateMachine.GetCurrentState() == PlayerState.discharging) {
            chargeableObject.charge(
                _playerCharge.Discharge(_dischargeSpeed)
            );
        }
    }
}
