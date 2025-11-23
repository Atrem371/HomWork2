using UnityEngine;

public class DistanceTracker : MonoBehaviour {
    public float distanceTravelled { get; private set; }
    private Vector3 startPosition;

    private void Start() {
        startPosition = transform.position;
    }

    private void Update() {
        distanceTravelled = transform.position.z - startPosition.z;
    }
}


