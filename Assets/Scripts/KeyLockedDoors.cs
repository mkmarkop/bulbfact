using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLockedDoors : Interactable {
    private Animator _animator;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}

    override
    protected void Interact()
    {
        _animator.SetBool("open", true);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
