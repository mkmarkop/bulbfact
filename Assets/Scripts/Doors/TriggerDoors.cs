using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoors : MonoBehaviour {
    private Animator _animator;
    private BoxCollider _boxCollider;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _animator.SetBool("open", true);
        }
    }
    // Update is called once per frame
    void Update () {
        
    }
}
