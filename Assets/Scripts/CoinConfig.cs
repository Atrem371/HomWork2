using UnityEngine;

[CreateAssetMenu(fileName = "CoinConfig", menuName = "Configs/CoinConfig")]
public class CoinConfig : ScriptableObject {
    [SerializeField] private int _value = 1;

    public int Value => _value;
}


