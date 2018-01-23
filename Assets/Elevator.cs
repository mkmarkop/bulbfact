using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    private Animator _animator;
    private BoxCollider _boxCollider;
    internal bool _open;

    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
        _open = false;
    }

    protected void Open()
    {
        _open = true;
        _animator.SetBool("open", true);
    }

    void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) { return; }
        if (Input.GetButtonDown("Activate"))
        {
            if (isOpen()) { return; }
            Open();
        }
    }

    bool isOpen()
    {
        return _open;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
