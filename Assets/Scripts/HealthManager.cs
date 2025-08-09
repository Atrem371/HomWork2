using UnityEngine;

public class HealthManager : MonoBehaviour {
    public static HealthManager Instance { get; private set; }

    private int currentHealth;
    private int maxHealth;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;


        maxHealth = Object.FindAnyObjectByType<HeartUI>()?.MaxHearts ?? 3;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;

        
        HeartUI.Instance?.SetHealth(currentHealth);

        Debug.Log("Player took damage: " + amount + ", current health: " + currentHealth);
    }

    public void Heal(int amount) {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        HeartUI.Instance?.SetHealth(currentHealth);

        Debug.Log("Player healed: " + amount + ", current health: " + currentHealth);
    }
}

