using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChargeableObject))]
public class Discharger : MonoBehaviour {
    public ChargeableObject ChargeableObject;
    private Object _player;

	// Use this for initialization
	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
