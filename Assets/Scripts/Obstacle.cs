using UnityEngine;
using MoreMountains.Feedbacks;
using Cinemachine;
using System.Collections;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class Obstacle : MonoBehaviour {
    private const string PLAYER_TAG = "Player";

    private CinemachineImpulseSource _impulseSource;
    private MMF_Player _blinkFeedback;
    private Renderer _playerRenderer;
    private HealthManager _healthManager;
    private Color _originalColor;

    private void Awake() {
        _impulseSource = GetComponent<CinemachineImpulseSource>();

           
        if (GameReferences.Instance != null) {
            _blinkFeedback = GameReferences.Instance.BlinkFeedback;
            _playerRenderer = GameReferences.Instance.PlayerRenderer;
            _healthManager = GameReferences.Instance.HealthManager;

            if (_playerRenderer != null)
                _originalColor = _playerRenderer.material.color;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(PLAYER_TAG)) return;

        _healthManager?.TakeDamage(1);
        _impulseSource.GenerateImpulse();

        if (_playerRenderer != null)
            StartCoroutine(BlinkRed());
    }

    private IEnumerator BlinkRed() {
        _playerRenderer.material.color = Color.red;
        _blinkFeedback?.PlayFeedbacks();

        yield return new WaitForSeconds(0.2f);

        _playerRenderer.material.color = _originalColor;
    }
}




















