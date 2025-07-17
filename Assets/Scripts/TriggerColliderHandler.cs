using UnityEngine;

public class TriggerTest : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        Debug.Log("Enter trigger: " + other.name);
    }

    void OnTriggerExit(Collider other) {
        Debug.Log("Exit trigger: " + other.name);
    }
}

