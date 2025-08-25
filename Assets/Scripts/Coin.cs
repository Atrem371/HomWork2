using UnityEngine;
using JSAM;

public class Coin : MonoBehaviour {
    [SerializeField] private CoinConfig _config;
    public CoinConfig Config => _config;

    private const string PlayerTag = "Player";

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(PlayerTag)) {
            AudioManager.PlaySound(MusicAudioLibrarySounds.Ñoin);

            if (PlayerGold.Instance != null) {
                PlayerGold.Instance.AddGold(Config.Value);
            }

            Destroy(gameObject);
        }
    }
}






