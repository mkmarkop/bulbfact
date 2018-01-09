using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorScript : MonoBehaviour {

    private Animator _animator;
    private bool _open;
    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
        _open = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void Open()
    {
       _animator.SetBool("open", true);
        _open = true;
    }
    
    internal bool isOpen()
    {
        return _open;
    }
}
