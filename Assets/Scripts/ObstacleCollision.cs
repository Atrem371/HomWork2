using UnityEngine;

public class ObstacleCollision : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Animator playerAnimator = collision.gameObject.GetComponent<Animator>();
            if (playerAnimator != null)
                playerAnimator.SetTrigger("IsHit");

            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
                playerController.Hit();
        }
    }
}

