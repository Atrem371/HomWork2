using UnityEngine;

public class HealthManager : MonoBehaviour {
    public static HealthManager Instance { get; private set; }

    [SerializeField] private HeartUI heartUI;
    [SerializeField] private GameObject player;
    [SerializeField] private GameOverUI gameOverUI;
    [SerializeField] private DistanceTracker distanceTracker; 

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

        if (distanceTracker == null)
            Debug.LogWarning("DistanceTracker is not assigned in HealthManager!");
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        heartUI.SetHealth(currentHealth);
        Debug.Log($"Player took damage: {amount}, current health: {currentHealth}");

        if (currentHealth <= 0) {
            Die();
        }
    }

    public void Heal(int amount) {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        heartUI.SetHealth(currentHealth);
        Debug.Log($"Player healed: {amount}, current health: {currentHealth}");
    }

    private void Die() {
        Debug.Log("Player Died!");

        
        if (player != null)
            player.SetActive(false);

        
        float distance = 0f;
        if (distanceTracker != null)
            distance = distanceTracker.distanceTravelled;

        int distanceScore = Mathf.FloorToInt(distance); 

        
        if (HighScoreManager.Instance != null) {
            HighScoreManager.Instance.SetHighScore(distanceScore, distance);
            Debug.Log($"HighScoreManager updated: score={distanceScore}, lastDistance={distance}");
        }

        
        if (gameOverUI != null)
            gameOverUI.ShowGameOver(distance);
        else
            Debug.LogWarning("GameOverUI is not assigned in HealthManager!");
    }
}








