using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private Transform _camTransform;
    public Transform lookAt;
    private Camera _cam;
    private float _distance;
    private float _currentX;
    private float _currentY;
    private float _sensitivityX;
    private float _sensitivityY;

    // Use this for initialization
    void Start ()
    {
        _camTransform = transform;
        _cam = Camera.main;
	}

    // Update is called once per frame
    void Update()
    {
        //_currentX += Input.GetAxis("Horizontal");
        //_currentY += Input.GetAxis("Vertical");
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -_distance);
        Quaternion rotation = Quaternion.Euler(_currentX, _currentY, 0);
        _camTransform.position = lookAt.position + rotation * dir;
        _camTransform.LookAt(lookAt.position);
    }

}
