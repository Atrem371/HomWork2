using UnityEngine;

public class HeartUI : MonoBehaviour {
    [SerializeField] private GameObject[] redHearts;
    [SerializeField] private int maxHearts = 3;
    private int currentHearts;

    public int MaxHearts => maxHearts;

    private void Start() {
        currentHearts = maxHearts;
        UpdateHearts();
    }

    public void SetHealth(int health) {
        currentHearts = Mathf.Clamp(health, 0, maxHearts);
        UpdateHearts();
    }

    public void TakeDamage(int amount) {
        SetHealth(currentHearts - amount);
    }

    public void Heal(int amount) {
        SetHealth(currentHearts + amount);
    }

    private void UpdateHearts() {
        for (int i = 0; i < redHearts.Length; i++) {
            redHearts[i].SetActive(i < currentHearts);
        }
    }
}







