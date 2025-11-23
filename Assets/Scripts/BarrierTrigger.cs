using UnityEngine;
using JSAM; 

public class BarrierTrigger : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            
            AudioManager.PlaySound(MusicAudioLibrarySounds.Hit); 

            BarrierObstacle playerCollision = other.GetComponent<BarrierObstacle>();
            if (playerCollision != null) {
                playerCollision.Hit();
            }
        }
    }
}
