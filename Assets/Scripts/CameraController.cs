using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Transform _camTransform;
    public Transform lookAt;
	
	void Start () {
        _camTransform = transform;
	}

	void LateUpdate () {
        _camTransform.position = new Vector3(_camTransform.position.x,
            _camTransform.position.y, lookAt.position.z);
	}
}
