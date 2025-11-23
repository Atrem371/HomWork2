using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour {
    private const string PLAYER_TAG = "Player";
    private bool canDamage = true;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(PLAYER_TAG) && canDamage) {
            PlayerService.Instance?.TakeDamage(1);
            StartCoroutine(DamageCooldown());
        }
    }

    private IEnumerator DamageCooldown() {
        canDamage = false;
        yield return new WaitForSeconds(0.5f);
        canDamage = true;
    }
}













































