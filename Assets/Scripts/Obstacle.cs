using UnityEngine;
using MoreMountains.Feedbacks;
using Cinemachine;
using System.Collections;

public class Obstacle : MonoBehaviour {
    private const string PLAYER_TAG = "Player";

    private HealthManager _healthManager;
    private Renderer[] _playerRenderers;
    private CinemachineImpulseSource _impulseSource;
    private MMF_Player _blinkFeedback;
    private Color[] _originalColors;
    private bool canDamage = true;

    private void Awake() {
        if (PlayerService.Instance != null) {
            _healthManager = PlayerService.Instance.HealthManager;
            _playerRenderers = PlayerService.Instance.PlayerRenderers;
            _impulseSource = PlayerService.Instance.ImpulseSource;
            _blinkFeedback = PlayerService.Instance.BlinkFeedback;

            if (_playerRenderers != null) {
                _originalColors = new Color[_playerRenderers.Length];
                for (int i = 0; i < _playerRenderers.Length; i++) {
                    _originalColors[i] = _playerRenderers[i].material.color;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(PLAYER_TAG) && canDamage) {
            _healthManager?.TakeDamage(1);
            _blinkFeedback?.PlayFeedbacks();
            _impulseSource?.GenerateImpulse();
            BlinkPlayer();
            StartCoroutine(DamageCooldown());
        }
    }

    private void BlinkPlayer() {
        if (_playerRenderers == null || _originalColors == null) return;

        for (int i = 0; i < _playerRenderers.Length; i++) {
            _playerRenderers[i].material.color = Color.red;
        }

        Invoke(nameof(ResetColors), 0.2f);
    }

    private void ResetColors() {
        if (_playerRenderers == null || _originalColors == null) return;

        for (int i = 0; i < _playerRenderers.Length; i++) {
            _playerRenderers[i].material.color = _originalColors[i];
        }
    }

    private IEnumerator DamageCooldown() {
        canDamage = false;
        yield return new WaitForSeconds(0.5f);
        canDamage = true;
    }
}












































