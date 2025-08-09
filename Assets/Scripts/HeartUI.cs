using UnityEngine;

public class HeartUI : MonoBehaviour {
    public static HeartUI Instance { get; private set; }

    [SerializeField] private GameObject[] redHearts;
    [SerializeField] private int maxHearts = 3;
    private int currentHearts;

    public int MaxHearts => maxHearts;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start() {
        currentHearts = maxHearts;
        UpdateHearts();
    }

    public void SetHealth(int health) {
        currentHearts = health;
        if (currentHearts > maxHearts) currentHearts = maxHearts;
        if (currentHearts < 0) currentHearts = 0;
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





