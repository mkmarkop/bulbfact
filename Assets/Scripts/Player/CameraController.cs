using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class CameraController : MonoBehaviour {
    private Transform _camTransform;
    public Transform lookAt;
    private Camera _cam;
    private PlayerState _currentState;
    private bool _hasToBeMoved;

    private void OnEnable()
    {
        //PlayerStateMachine.onStateChange += playerStateChangeListener;
    }

    private void OnDisable()
    {
        //PlayerStateMachine.onStateChange -= playerStateChangeListener;
    }

    private void playerStateChangeListener(PlayerState ps)
    {
        //ne treba:
        //_hasToBeMoved = 
        //    ps == PlayerState.walkingBackward ||
        //    ps == PlayerState.walkingForward ||
        //    ps == PlayerState.walkingLeft ||
        //    ps == PlayerState.walkingRight ||
        //    ps == PlayerState.glidingBackward ||
        //    ps == PlayerState.glidingForward ||
        //    ps == PlayerState.glidingLeft ||
        //    ps == PlayerState.glidingRight;
        //Debug.Log(ps.ToString());
    }
    // Use this for initialization
    void Start ()
    {
        _camTransform = transform;
        _cam = Camera.main;
	}

    // Update is called once per frame
    void Update()
    {
        // ne treba:
        // if (_hasToBeMoved)
        // {
        //    _delta += Input.GetAxis("Horizontal") / 15;
        // }
    }

    void LateUpdate()
    {
        _camTransform.position = new Vector3(_camTransform.position.x, _camTransform.position.y, lookAt.position.z);
    }

}
