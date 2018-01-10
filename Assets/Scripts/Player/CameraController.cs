using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class CameraController : MonoBehaviour {
    private Transform _camTransform;
    public Transform lookAt;
    private Camera _cam;
    private Vector3 offset = new Vector3(30f, 10f, 0f);
    private float _distance;
    private float _currentX;
    private float _currentY;
    private float _sensitivityX = 15f;
    private float _sensitivityY = 15f;

    // Use this for initialization
    void Start ()
    {
        _camTransform = transform;
        _cam = Camera.main;
	}

    // Update is called once per frame
    void Update()
    {
        _currentX += Input.GetAxis("Horizontal");
        _currentY += Input.GetAxis("Vertical");
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0f, 0f, -_distance);
        Quaternion rotation = Quaternion.Euler(_currentX * _sensitivityX, _currentY * _sensitivityY, 0);
        _camTransform.position = lookAt.position + rotation * dir + offset;
        _camTransform.LookAt(lookAt.position);
    }

}
