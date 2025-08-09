using UnityEngine;

public class ObstacleHealt : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (HealthManager.Instance != null) {
                HealthManager.Instance.TakeDamage(1);
            }
            else {
                Debug.LogWarning("HealthManager Instance is null!");
            }
        }
    }
}

