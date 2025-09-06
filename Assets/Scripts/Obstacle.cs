using UnityEngine;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class Obstacle : MonoBehaviour {
    private const string PLAYER_TAG = "Player";
    private CinemachineImpulseSource _impulseSource;

    private List<Renderer> _playerRenderers = new List<Renderer>();
    private List<Color> _originalColors = new List<Color>();

    private void Awake() {
        _impulseSource = GetComponent<CinemachineImpulseSource>();

        
        GameObject player = GameObject.FindGameObjectWithTag(PLAYER_TAG);
        if (player != null) {
            
            _playerRenderers.AddRange(player.GetComponentsInChildren<Renderer>());

            
            foreach (var r in _playerRenderers) {
                _originalColors.Add(r.material.color);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(PLAYER_TAG)) return;

        
        HealthManager.Instance?.TakeDamage(1);

        
        _impulseSource.GenerateImpulse();

        
        if (_playerRenderers.Count > 0)
            StartCoroutine(BlinkRedCoroutine());
    }

    private IEnumerator BlinkRedCoroutine() {
        
        for (int i = 0; i < _playerRenderers.Count; i++) {
            _playerRenderers[i].material.color = Color.red;
        }

        yield return new WaitForSeconds(0.2f);

        
        for (int i = 0; i < _playerRenderers.Count; i++) {
            _playerRenderers[i].material.color = _originalColors[i];
        }
    }
}































