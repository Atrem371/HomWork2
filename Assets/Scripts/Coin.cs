using UnityEngine;

public class Coin : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            PlayerGold playerGold = other.GetComponent<PlayerGold>();
            if (playerGold != null) {
                playerGold.AddGold(1);
            }
            else {
                Debug.LogWarning("PlayerGoldNotFound");
            }
            Destroy(gameObject);
        }
    }
}


