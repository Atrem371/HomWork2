using UnityEngine;

public class DistanceTracker : MonoBehaviour {
    public float distanceTravelled { get; private set; }
    private Vector3 startPosition;

    private void Start() {
        startPosition = transform.position;
        Debug.Log($"Start position: {startPosition.z}");
    }

    private void Update() {
        distanceTravelled = transform.position.z - startPosition.z;

        
        Debug.Log($"Distance travelled: {distanceTravelled}");
    }
}


