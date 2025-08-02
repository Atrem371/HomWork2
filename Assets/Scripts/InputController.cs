using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputController : IDisposable {
    private NewControls controls;

    public event Action<Vector2> MovementReceived;
    public event Action JumpPressed;

    public InputController() {
        controls = new NewControls();
        controls.Enable();

        controls.Default.Movement.performed += OnMove;
        controls.Default.Movement.canceled += OnMove;
        controls.Default.Jump.performed += OnJump;
    }

    private void OnMove(InputAction.CallbackContext ctx) {
        MovementReceived?.Invoke(ctx.ReadValue<Vector2>());
    }

    private void OnJump(InputAction.CallbackContext ctx) {
        JumpPressed?.Invoke();
    }

    public void Dispose() {
        controls.Default.Movement.performed -= OnMove;
        controls.Default.Movement.canceled -= OnMove;
        controls.Default.Jump.performed -= OnJump;
        controls.Disable();
        controls.Dispose();
    }
}


