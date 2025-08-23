using UnityEngine;

public class PlayerGold : MonoBehaviour {
    public static PlayerGold Instance { get; private set; }

    [SerializeField] private GoldUI goldUI;
    private int gold = 0;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddGold(int amount) {
        gold += amount;

        if (goldUI != null) {
            goldUI.AddGold(amount);
        }
    }
}



