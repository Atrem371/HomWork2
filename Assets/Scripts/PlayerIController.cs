using UnityEngine;
using Dreamteck.Forever;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour {
    private InputController _inputController;
    [SerializeField] private Runner _basicRunner;

    [SerializeField] private Animator _animator;
    private const string RunningBool = "IsRunning";
    private const string JumpBool = "IsJumping";
    private const string HitTrigger = "IsHit";
    
        

    private float _target;
    [SerializeField] private float horizontalOffsetMultiplier = 3f;

    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float jumpDecay = 5f;
    private float verticalVelocity = 0f;
    private bool isJumping = false;

    private void Awake() {
        _inputController = new InputController();

        if (_animator == null)
            _animator = GetComponent<Animator>();

        _animator.SetBool(RunningBool, true);

        SubscribeEvents();
    }

    private void SubscribeEvents() {
        _inputController.MovementReceived += OnMovementReceived;
        _inputController.JumpPressed += OnJumpPressed;
    }

    private void UnsubscribeEvents() {
        _inputController.MovementReceived -= OnMovementReceived;
        _inputController.JumpPressed -= OnJumpPressed;
    }

    private void OnMovementReceived(Vector2 movement) {
        _target = movement.x;
    }

    private void OnJumpPressed() {
        if (!isJumping) {
            isJumping = true;
            verticalVelocity = jumpForce;
            _animator.SetBool(JumpBool, true);
        }
    }

    private void Update() {
        UpdateMovement();
    }

    private void UpdateMovement() {
        if (isJumping) {
            verticalVelocity -= jumpDecay * Time.deltaTime;

            if (_basicRunner != null) {
                _basicRunner.motion.offset = new Vector2(
                    _target * horizontalOffsetMultiplier,
                    verticalVelocity
                );
            }

            if (verticalVelocity <= 0) {
                isJumping = false;
                verticalVelocity = 0;
                _animator.SetBool(JumpBool, false);
            }
        }
        else {
            if (_basicRunner != null) {
                _basicRunner.motion.offset = new Vector2(
                    _target * horizontalOffsetMultiplier,
                    0f
                );
            }
        }

        bool isRunning = Mathf.Abs(_target) > 0.1f;
        _animator.SetBool(RunningBool, isRunning);
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("Hit: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Obstacle")) {
            _animator.SetTrigger(HitTrigger);
        }
    }

    private void OnDestroy() {
        UnsubscribeEvents();
        _inputController.Dispose();
    }
}













