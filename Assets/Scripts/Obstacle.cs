using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour {
    private void Reset() {
        
        GetComponent<Collider>().isTrigger = true;

        
        if (gameObject.tag != "Obstacle")
            gameObject.tag = "Obstacle";
    }
}
