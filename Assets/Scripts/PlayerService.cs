using UnityEngine;
using MoreMountains.Feedbacks;
using Cinemachine;
using System.Collections;

public class PlayerService : MonoBehaviour {
    public static PlayerService Instance { get; private set; }

    [SerializeField] private HealthManager healthManager;
    [SerializeField] private Renderer[] playerRenderers;
    [SerializeField] private MMF_Player blinkFeedback;
    [SerializeField] private CinemachineImpulseSource impulseSource;

    private Color[] originalColors;
    private Coroutine blinkCoroutine;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        if (playerRenderers != null) {
            originalColors = new Color[playerRenderers.Length];
            for (int i = 0; i < playerRenderers.Length; i++) {
                originalColors[i] = playerRenderers[i].material.color;
            }
        }
    }

    public void TakeDamage(int amount) {
        if (healthManager != null) {
            healthManager.TakeDamage(amount);
        }

        blinkFeedback?.PlayFeedbacks();
        impulseSource?.GenerateImpulse();
        StartBlink();
    }

    private void StartBlink() {
        if (blinkCoroutine != null)
            StopCoroutine(blinkCoroutine);

        blinkCoroutine = StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine() {
        if (playerRenderers == null || originalColors == null)
            yield break;

        for (int i = 0; i < playerRenderers.Length; i++)
            playerRenderers[i].material.color = Color.red;

        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < playerRenderers.Length; i++)
            playerRenderers[i].material.color = originalColors[i];

        blinkCoroutine = null;
    }
}


















