using UnityEngine;

public class PlayerGold : MonoBehaviour {
    public GoldUI goldUI;  

    private int gold = 0;

    public void AddGold(int amount) {
        gold += amount;
        Debug.Log("Money,Money,Money,Must be funny,In the rich mans world : " + gold);
        if (goldUI != null) {
            goldUI.AddGold(amount);
        }
    }
}

