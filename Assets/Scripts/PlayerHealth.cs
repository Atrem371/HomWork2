using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public HeartUI heartUI;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Obstacle")) {
            heartUI.TakeDamage(1);
            Debug.Log("Damag");
        }
    }
}


