using UnityEngine;
using JSAM;

public class Coin : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {

            AudioManager.PlaySound(MusicAudioLibrarySounds.Ñoin);

            if (PlayerGold.Instance != null) {
                PlayerGold.Instance.AddGold(1);
            }

            Destroy(gameObject);
        }
    }
}





