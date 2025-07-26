using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputController : IDisposable {
    private readonly NewControls _inputActions;
    public event Action<Vector2> MovementReceived;

    public InputController() {
        _inputActions = new NewControls();
        _inputActions.Enable();

        _inputActions.Default.Movement.performed += OnMovementPerformed;
        _inputActions.Default.Movement.canceled += OnMovementPerformed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context) {
        Vector2 input = context.ReadValue<Vector2>();
        MovementReceived?.Invoke(input);
    }

    public void Dispose() {
        _inputActions.Default.Movement.performed -= OnMovementPerformed;
        _inputActions.Default.Movement.canceled -= OnMovementPerformed;
        _inputActions.Dispose();
    }
}

