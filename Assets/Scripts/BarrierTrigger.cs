using UnityEngine;

public class BarrierTrigger : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            BarrierObstacle playerCollision = other.GetComponent<BarrierObstacle>();
            if (playerCollision != null) {
                playerCollision.Hit();
            }
        }
    }
}
