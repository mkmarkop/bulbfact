using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStateMachine))]

public class PlayerController : MonoBehaviour
{
    private PlayerStateMachine pMachine;
    private Rigidbody body;

	// Use this for initialization
	void Start () {
		pMachine = GetComponent<PlayerStateMachine> ();
	}

    // Update is called once per frame
    void Update()
    {
        bool isMovingHorizontal = true;
        bool isMovingVertical = true;
        bool isGliding = pMachine.currentState == PlayerState.glidingBackward ||
                         pMachine.currentState == PlayerState.glidingForward ||
                         pMachine.currentState == PlayerState.glidingLeft ||
                         pMachine.currentState == PlayerState.glidingRight;
        bool isFalling = pMachine.currentState == PlayerState.fall;
        float jump = Input.GetAxis("Jump");
        if (jump > 0.0f)
        {
            pMachine.tryStateChange(PlayerState.jump);
        }
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal == 0)
        {
            isMovingHorizontal = false;
            pMachine.tryStateChange(PlayerState.idle);
        }
        else if (horizontal < 0f)
        {
            if (isGliding || isFalling)
            {
                pMachine.tryStateChange(PlayerState.glidingBackward);
            }
            else
            {
                pMachine.tryStateChange(PlayerState.walkingBackward);
            }
        }
        else if (horizontal > 0f)
        {
            if (isGliding || isFalling)
            {
                pMachine.tryStateChange(PlayerState.glidingForward);
            }
            else
            {
                pMachine.tryStateChange(PlayerState.walkingForward);
            }
        }

        float vertical = Input.GetAxis("Vertical");
        if(vertical == 0)
        {
            isMovingVertical = false;
        }
        if (vertical < 0f)
        {
            if (isGliding || isFalling)
            {
                pMachine.tryStateChange(PlayerState.glidingLeft);
            }
            else
            {
                pMachine.tryStateChange(PlayerState.walkingLeft);
            }
        }
        else if (vertical > 0f)
        {
            if (isGliding || isFalling)
            {
                pMachine.tryStateChange(PlayerState.glidingRight);
            }
            else
            {
                pMachine.tryStateChange(PlayerState.walkingRight);
            }
        }
        if (!isMovingVertical && !isMovingHorizontal)
        {
            if (isFalling || isGliding)
            {
                pMachine.tryStateChange(PlayerState.fall);
            }
        }
    }

}
