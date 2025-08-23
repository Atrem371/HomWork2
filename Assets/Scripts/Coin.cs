using UnityEngine;
using JSAM;

public class Coin : MonoBehaviour {
    public CoinConfig config; 

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            AudioManager.PlaySound(MusicAudioLibrarySounds.Ñoin);

            if (PlayerGold.Instance != null) {
                PlayerGold.Instance.AddGold(config.value); 
            }

            Destroy(gameObject);
        }
    }
}





