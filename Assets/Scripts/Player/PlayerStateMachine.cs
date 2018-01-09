using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerStateMachine : MonoBehaviour {

    public delegate void playerStateHandler(PlayerState newState);
    public static event playerStateHandler onStateChange;

    public float playerWalkSpeed = 1.0f;

    private Vector3 playerForward;
    private Vector3 playerOrientation;
    private Animator playerAnimator;
    private PlayerState currentState;

    // Use this for initialization
    void Start() {
        playerForward = Vector3.forward;
        playerAnimator = GetComponent<Animator>();
        currentState = PlayerState.idle;
    }

    // Update is called once per frame
    void Update() {
        onStateCycle();
    }

    bool isValidTransition(PlayerState newState) {
        bool isValid = false;

        switch (currentState) {
            case PlayerState.idle:
                isValid = true;
                break;

            case PlayerState.walkingLeft:
                isValid = true;
                break;

            case PlayerState.walkingRight:
                isValid = true;
                break;

            case PlayerState.walkingForward:
                isValid = true;
                break;

            case PlayerState.walkingBackward:
                isValid = true;
                break;

            case PlayerState.charging:
                isValid = newState != PlayerState.idle;
                break;

            case PlayerState.discharging:
                isValid = newState != PlayerState.idle;
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
                walk();
                break;

            case PlayerState.walkingRight:
                walk();
                break;

            case PlayerState.walkingForward:
                walk();
                break;

            case PlayerState.walkingBackward:
                walk();
                break;

            default:
                break;
        }
    }

    void walk() {
        transform.Translate(playerForward * playerWalkSpeed * Time.deltaTime, Space.World);
    }

    void faceTowards(Vector3 dir) {
        playerAnimator.SetBool("walking", true);
        playerForward = dir;
        transform.rotation = Quaternion.LookRotation(playerForward);
    }

    public void tryStateChange(PlayerState newState) {
        if (currentState == newState)
            return;

        if (!isValidTransition(newState))
            return;

        switch (newState) {
            case PlayerState.idle:
                playerAnimator.SetBool("walking", false);
                break;

            case PlayerState.walkingLeft:
                faceTowards(-Vector3.left);
                break;

            case PlayerState.walkingRight:
                faceTowards(-Vector3.right);
                break;

            case PlayerState.walkingForward:
                faceTowards(Vector3.forward);
                break;

            case PlayerState.walkingBackward:
                faceTowards(Vector3.back);
                break;

            default:
                break;
        }

        currentState = newState;
        if (onStateChange != null) {
            onStateChange(currentState);
        }
    }
    public PlayerState GetCurrentState(){
        return currentState;
    }
}
