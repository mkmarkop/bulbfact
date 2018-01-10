using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerStateMachine : MonoBehaviour {
    
    private Rigidbody _playerBody;
	public delegate void playerStateHandler(PlayerState newState);
	public static event playerStateHandler onStateChange;

    public float playerWalkSpeed = 1.0f;
    public float playerJumpIntensity = 85.0f;

    private Vector3 playerForward;
	private Vector3 playerOrientation;
	private Animator playerAnimator;
	public PlayerState currentState;

    private bool allowedToJump;

	// Use this for initialization
	void Start () {
		playerForward = Vector3.forward;
		playerAnimator = GetComponent<Animator> ();
		currentState = PlayerState.idle;
        _playerBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		onStateCycle ();
	}

	bool isValidTransition(PlayerState newState) {
		bool isValid = false;

		switch (currentState) {

        case PlayerState.idle:
		    isValid = newState != PlayerState.fall;
		    break;

        case PlayerState.grounded:
            isValid = newState != PlayerState.fall;
            break;

        case PlayerState.walkingLeft:
            isValid =
                newState != PlayerState.fall &&
                newState != PlayerState.glidingBackward &&
                newState != PlayerState.glidingForward &&
                newState != PlayerState.glidingLeft &&
                newState != PlayerState.glidingRight;
            break;

		case PlayerState.walkingRight:
                isValid =
                    newState != PlayerState.fall &&
                    newState != PlayerState.glidingBackward &&
                    newState != PlayerState.glidingForward &&
                    newState != PlayerState.glidingLeft &&
                    newState != PlayerState.glidingRight;
                break;

		case PlayerState.walkingForward:
                isValid =
                    newState != PlayerState.fall &&
                    newState != PlayerState.glidingBackward &&
                    newState != PlayerState.glidingForward &&
                    newState != PlayerState.glidingLeft &&
                    newState != PlayerState.glidingRight;
                break;

        case PlayerState.walkingBackward:
                isValid =
                    newState != PlayerState.fall &&
                    newState != PlayerState.glidingBackward &&
                    newState != PlayerState.glidingForward &&
                    newState != PlayerState.glidingLeft &&
                    newState != PlayerState.glidingRight;
                break;

        case PlayerState.jump:
                isValid =
                        newState == PlayerState.fall ||
                        newState == PlayerState.glidingLeft ||
                        newState == PlayerState.glidingRight ||
                        newState == PlayerState.glidingForward ||
                        newState == PlayerState.glidingBackward;
            break;

        case PlayerState.fall:
                isValid = 
                        newState == PlayerState.glidingLeft ||
                        newState == PlayerState.glidingRight ||
                        newState == PlayerState.glidingForward ||
                        newState == PlayerState.glidingBackward ||
                        newState == PlayerState.grounded;
                break;

        case PlayerState.glidingForward:
            isValid =
                    newState == PlayerState.grounded ||
                    newState == PlayerState.fall;
                break;

        case PlayerState.glidingBackward:
                isValid = 
                    newState == PlayerState.grounded ||
                    newState == PlayerState.fall;
            break;

        case PlayerState.glidingLeft:
                isValid = 
                    newState == PlayerState.grounded ||
                    newState == PlayerState.fall;
            break;

        case PlayerState.glidingRight:
            isValid = 
                    newState == PlayerState.grounded ||
                    newState == PlayerState.fall;
            break;

            default:
			break;
		}

		return isValid;
	}

	void onStateCycle() {
		switch (currentState) {
		case PlayerState.idle:
			break;

		case PlayerState.walkingLeft:
            walk ();
			break;

		case PlayerState.walkingRight:
            walk ();
			break;

		case PlayerState.walkingForward:
            walk ();
			break;

		case PlayerState.walkingBackward:
            walk ();
			break;

        case PlayerState.glidingLeft:
            glide();
            break;
        
        case PlayerState.glidingRight:
            glide();
            break;
        
        case PlayerState.glidingForward:
            glide();
            break;
        
        case PlayerState.glidingBackward:
            glide();
            break;

        case PlayerState.jump:
            break;

        case PlayerState.fall:
            break;

            default:
			break;
		}
	}

	void walk() {
        transform.Translate(playerForward * playerWalkSpeed * Time.deltaTime, Space.World);
    }

    void jump()
    {
        _playerBody.AddForce(Vector3.up * playerJumpIntensity);
    }

    void glide()
    {
        transform.Translate(playerForward * playerWalkSpeed * 0.0f * Time.deltaTime, Space.World);
    }

    void faceTowards(Vector3 dir) {
		playerAnimator.SetBool ("walking", true);
		playerForward = dir;
		transform.rotation = Quaternion.LookRotation (playerForward);
	}

	public void tryStateChange(PlayerState newState) {
		if (currentState == newState)
			return;

        if (newState == PlayerState.jump && !allowedToJump)
            return;

        if (!isValidTransition (newState))
			return;
        

		switch (newState) {
		case PlayerState.idle:
			playerAnimator.SetBool ("walking", false);
			break;

		case PlayerState.walkingLeft:
			faceTowards (-Vector3.left);
			break;

		case PlayerState.walkingRight:
            faceTowards (-Vector3.right);
			break;

		case PlayerState.walkingForward:
            faceTowards (Vector3.forward);
			break;

		case PlayerState.walkingBackward:
            faceTowards (Vector3.back);
			break;

        case PlayerState.glidingLeft:
            faceTowards(-Vector3.left);
            break;

        case PlayerState.glidingRight:
            faceTowards(-Vector3.right);
            break;

        case PlayerState.glidingForward:
            faceTowards(Vector3.forward);
            break;

        case PlayerState.glidingBackward:
            faceTowards(Vector3.back);
            break;

        case PlayerState.jump:
            jump();
            break;

        default:
			break;

		}

		currentState = newState;
		if (onStateChange != null) {
			onStateChange(currentState);
        }

        if (currentState == PlayerState.jump)
        {
            tryStateChange(PlayerState.fall);
        } else if (currentState == PlayerState.grounded)
        {
            tryStateChange(PlayerState.idle);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            allowedToJump = true;
            tryStateChange(PlayerState.grounded);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            allowedToJump = false;
        }
    }

}
