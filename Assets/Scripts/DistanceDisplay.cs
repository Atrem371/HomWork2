using UnityEngine;
using TMPro; 

public class DistanceDisplay : MonoBehaviour {
    public TextMeshProUGUI distanceText; 
    public DistanceTracker tracker;

    private void Update() {
        if (tracker != null && distanceText != null) {
            int distance = Mathf.FloorToInt(tracker.distanceTravelled);
            distanceText.text = "Distance: " + distance + " m";
        }
    }
}


