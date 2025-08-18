using TMPro;
using UnityEngine;

public class LastDistanceDisplay : MonoBehaviour {
    [SerializeField] private TMP_Text distanceText;

    private void Start() {
        if (distanceText == null) {
            Debug.LogError("DistanceText не прив’язаний у LastDistanceDisplay!");
            return;
        }

        
        if (HighScoreManager.Instance != null) {
            float lastDistance = HighScoreManager.Instance.LastDistance;
            distanceText.text = $"Last Distance: {Mathf.FloorToInt(lastDistance)} m";
        }
        else {
            distanceText.text = "Last Distance: 0 m";
        }
    }
}

