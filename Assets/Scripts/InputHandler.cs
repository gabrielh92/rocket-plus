using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public void OnThrust(InputAction.CallbackContext context) {
        var controller = GetComponent<RocketController>();
        switch(context.phase) {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:
                controller.EnableThrust();
                break;
            case InputActionPhase.Canceled:
                controller.DisableThrust();
                break;
            default:
                break;
        }
    }

    public void OnCwRotation(InputAction.CallbackContext context) {
        var controller = GetComponent<RocketController>();
        switch(context.phase) {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:
                controller.EnableCwRotation();
                break;
            case InputActionPhase.Canceled:
                controller.DisableCwRotation();
                break;
            default:
                break;
        }
    }

    public void OnCcwRotation(InputAction.CallbackContext context) {
        var controller = GetComponent<RocketController>();
        switch(context.phase) {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:
                controller.EnableCcwRotation();
                break;
            case InputActionPhase.Canceled:
                controller.DisableCcwRotation();
                break;
            default:
                break;
        }
    }
}
