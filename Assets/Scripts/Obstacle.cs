using UnityEngine;

public class Obstacle : MonoBehaviour {
    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(PLAYER_TAG)) {
            if (HealthManager.Instance != null) {
                HealthManager.Instance.TakeDamage(1);
            }
        }
    }
}



