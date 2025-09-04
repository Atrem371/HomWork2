using UnityEngine;
using MoreMountains.Feedbacks;
using Cinemachine;

public class Obstacle : MonoBehaviour {
    private const string PLAYER_TAG = "Player";

    private MMF_Player blinkFeedback;
    private CinemachineImpulseSource impulseSource;
    private Renderer playerRenderer;
    private Color originalColor;

    private void Start() {
        FindReferences();
    }

    private void FindReferences() {
        impulseSource = GetComponent<CinemachineImpulseSource>()
                        ?? GetComponentInChildren<CinemachineImpulseSource>();

        blinkFeedback = Object.FindFirstObjectByType<MMF_Player>();
        if (blinkFeedback == null) {
            foreach (var fb in Object.FindObjectsByType<MMF_Player>(FindObjectsSortMode.None)) {
                if (fb.gameObject.name.ToLower().Contains("blink")) {
                    blinkFeedback = fb;
                    break;
                }
            }
        }

        var player = GameObject.FindGameObjectWithTag(PLAYER_TAG);
        if (player != null) {
            playerRenderer = player.GetComponentInChildren<Renderer>();
            if (playerRenderer != null)
                originalColor = playerRenderer.material.color;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(PLAYER_TAG)) return;

        HealthManager.Instance?.TakeDamage(1);
        impulseSource?.GenerateImpulse();

        if (playerRenderer != null)
            StartCoroutine(BlinkRed());
    }

    private System.Collections.IEnumerator BlinkRed() {
        playerRenderer.material.color = Color.red;
        blinkFeedback?.PlayFeedbacks();
        yield return new WaitForSeconds(0.2f);
        playerRenderer.material.color = originalColor;
    }
}
















