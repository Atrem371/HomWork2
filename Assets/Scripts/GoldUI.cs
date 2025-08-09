using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour {
    public TextMeshProUGUI goldText;
    private int goldCount;

    public void AddGold(int amount) {
        goldCount += amount;
        goldText.text = goldCount.ToString();
    }
}
