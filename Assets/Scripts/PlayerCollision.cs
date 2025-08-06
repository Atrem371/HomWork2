using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    private PlayerController playerController;

    private void Awake() {
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Obstacle") && playerController != null) {
            playerController.Hit();
        }
    }
}

