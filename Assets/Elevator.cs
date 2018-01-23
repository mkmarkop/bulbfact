using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Elevator : Interactable {
    private Animator _animator;
    private BoxCollider _boxCollider;
    internal bool _open;

    // Use this for initialization
    void Start () {
        base.Start();
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
        _open = false;
    }

    protected void Open()
    {
        _open = true;
        _animator.SetBool("open", true);
    }

    protected override void Interact()
    {
        if (isOpen()) { return; }
        Open();
    }

    bool isOpen()
    {
        return _open;
    }
}
