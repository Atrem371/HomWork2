using Dreamteck.Forever;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private InputController _inputController;
    [SerializeField] private Runner _basicRunner;
    private float _target;

    private void Awake() {
        _inputController = new InputController();
        SubscribeEvents();
    }

    private void Start() {
    transform.position += new Vector3(-32.5f, 0, 0);
    }

    private void Update() {
        UpdateMovement();
    }

    private void SubscribeEvents() {
        _inputController.MovementReceived += OnMovementReceived;
    }

    private void UnsubscribeEvents() {
        _inputController.MovementReceived -= OnMovementReceived;
    }

    private void OnMovementReceived(Vector2 movement) {
        Debug.Log("movement " + movement);
        _target = movement.x;
    }

    private void UpdateMovement() {
        if (_basicRunner != null) {
            _basicRunner.motion.offset = new Vector2(_target, _basicRunner.motion.offset.y);
        }
    }

    private void OnDestroy() {
        UnsubscribeEvents();
        _inputController.Dispose();
    }
}







