using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class RocketController : MonoBehaviour
{
    [SerializeField] float thrustPower = 25f;
    [SerializeField] float rotationSpeed = 25f;
    [SerializeField] ForceMode2D forceMode;

    private Rigidbody2D rb;
    private RocketState thrustState;
    private RocketState cwRotationState;
    private RocketState ccwRotationState;

    enum RocketState {
        Enabled,
        Disabled
    }

    enum RocketRotationDirection {
        Cw,
        Ccw
    }

    private void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();

        thrustState = RocketState.Disabled;
        cwRotationState = RocketState.Disabled;
        ccwRotationState = RocketState.Disabled;
    }

    private void Update() {
        Thrust();
        Rotate();
    }

    private void Thrust() {
        if(thrustState.Equals(RocketState.Enabled)) {
            rb.AddRelativeForce(Vector2.up * Time.deltaTime * thrustPower,
                forceMode);
        }
    }

    private void Rotate() {
        float speed = Mathf.Clamp(rotationSpeed * Time.deltaTime, -0.66f, 0.66f);
        Debug.Log($"rotation before: {transform.rotation}");
        if(cwRotationState == RocketState.Enabled && ccwRotationState == RocketState.Enabled) {
            return; // if player is rotating both at the same time, don't rotate at all
        } else if(cwRotationState == RocketState.Enabled) {
            transform.Rotate(-1 * Vector3.forward * speed);
        } else if(ccwRotationState == RocketState.Enabled) {
            transform.Rotate(Vector3.forward * speed);
        }
        Debug.Log($"rotation after: {transform.rotation}");
    }

    public void EnableThrust() {
        thrustState = RocketState.Enabled;
    }

    public void DisableThrust() {
        thrustState = RocketState.Disabled;
    }

    public void EnableCwRotation() {
        cwRotationState = RocketState.Enabled;
    }

    public void DisableCwRotation() {
        cwRotationState = RocketState.Disabled;
    }

    public void EnableCcwRotation() {
        ccwRotationState = RocketState.Enabled;
    }

    public void DisableCcwRotation() {
        ccwRotationState = RocketState.Disabled;
    }
}
