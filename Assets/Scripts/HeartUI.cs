using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour {
    public Image[] hearts; 
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int maxHearts = 3;
    public int currentHearts;

    void Start() {
        currentHearts = maxHearts;
        UpdateHearts();
    }

    public void TakeDamage(int amount) {
        currentHearts -= amount;
        if (currentHearts < 0) currentHearts = 0;
        UpdateHearts();
    }

    public void Heal(int amount) {
        currentHearts += amount;
        if (currentHearts > maxHearts) currentHearts = maxHearts;
        UpdateHearts();
    }

    void UpdateHearts() {
        for (int i = 0; i < hearts.Length; i++) {
            hearts[i].sprite = (i < currentHearts) ? fullHeart : emptyHeart;
        }
    }
}

