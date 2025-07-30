using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputController : IDisposable {
    private readonly NewControls _inputActions;
    public event Action<Vector2> MovementReceived;
    public event Action JumpPressed;

    public InputController() {
        _inputActions = new NewControls();
        _inputActions.Enable();

        _inputActions.Default.Movement.performed += OnMovementPerformed;
        _inputActions.Default.Movement.canceled += OnMovementPerformed;

        _inputActions.Default.Jump.performed += ctx => JumpPressed?.Invoke();
    }

    private void OnMovementPerformed(InputAction.CallbackContext context) {
        Vector2 input = context.ReadValue<Vector2>();
        MovementReceived?.Invoke(input);
    }

    public void Dispose() {
        _inputActions.Default.Movement.performed -= OnMovementPerformed;
        _inputActions.Default.Movement.canceled -= OnMovementPerformed;

        _inputActions.Default.Jump.performed -= ctx => JumpPressed?.Invoke();

        _inputActions.Dispose();
    }
}

