using UnityEngine;
using System;

public class AudioManagerWrapper : MonoBehaviour {
    public static event Action OnInitialized;
    public static bool IsInitialized { get; private set; } = false;

    void Awake() {
        
        IsInitialized = true;

        
        OnInitialized?.Invoke();
    }
}



