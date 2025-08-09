using UnityEngine;

public class HealthManager : MonoBehaviour {
    public static HealthManager Instance { get; private set; }

    [SerializeField] private HeartUI heartUI; 

    private int currentHealth;
    private int maxHealth;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        if (heartUI == null) {
            Debug.LogError("HeartUI reference is missing in HealthManager!");
            return;
        }

        maxHealth = heartUI.MaxHearts;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        heartUI.SetHealth(currentHealth);
        Debug.Log($"Player took damage: {amount}, current health: {currentHealth}");
    }

    public void Heal(int amount) {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        heartUI.SetHealth(currentHealth);
        Debug.Log($"Player healed: {amount}, current health: {currentHealth}");
    }
}



