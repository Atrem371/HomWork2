using UnityEngine;
using Dreamteck.Forever;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour {
    private InputController inputController;
    [SerializeField] private Runner runner;
    [SerializeField] private Animator animator;

    private float moveX = 0f;
    private float jumpSpeed = 0f;
    private bool isJumping = false;

    [SerializeField] private float moveAmount = 3f;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float gravity = 3f;

    private const string RUN_BOOL = "IsRunning";
    private const string JUMP_TRIGGER = "IsJumping";
    private const string HIT_TRIGGER = "IsHit";

    private void Awake() {
        inputController = new InputController();

        if (animator == null)
            animator = GetComponent<Animator>();

        animator.SetBool(RUN_BOOL, true);

        inputController.MovementReceived += OnMove;
        inputController.JumpPressed += OnJump;
    }

    private void OnMove(Vector2 direction) {
        moveX = direction.x;
    }

    private void OnJump() {
        if (!isJumping) {
            isJumping = true;
            jumpSpeed = jumpForce;
            animator.SetTrigger(JUMP_TRIGGER);
        }
    }

    private void Update() {
        Vector2 offset = new Vector2(moveX * moveAmount, 0f);

        if (isJumping) {
            jumpSpeed -= gravity * Time.deltaTime;
            offset.y = jumpSpeed;

            if (jumpSpeed <= 0f) {
                jumpSpeed = 0f;
                isJumping = false;
            }
        }

        if (runner != null)
            runner.motion.offset = offset;

        animator.SetBool(RUN_BOOL, Mathf.Abs(moveX) > 0.1f);
    }

    public void Hit() {
        StartCoroutine(HitRoutine());
    }

    private IEnumerator HitRoutine() {
        enabled = false;
        animator.SetTrigger(HIT_TRIGGER);
        yield return new WaitForSeconds(1f);
        enabled = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Obstacle")) {
            Hit();
        }
    }

    private void OnDestroy() {
        inputController.MovementReceived -= OnMove;
        inputController.JumpPressed -= OnJump;
        inputController.Dispose();
    }
}














