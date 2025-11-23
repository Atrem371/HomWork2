using UnityEngine;

public class CoinSpawner : MonoBehaviour {
    public GameObject coinPrefab;

    void Start() {
        GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        coin.transform.SetParent(transform); 
        coin.transform.localPosition = Vector3.zero;
    }
}


