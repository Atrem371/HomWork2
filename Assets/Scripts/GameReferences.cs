using UnityEngine;
using MoreMountains.Feedbacks;
using Cinemachine;
using System.Collections;

public class GameReferences : MonoBehaviour {
    public static GameReferences Instance { get; private set; }

    public MMF_Player BlinkFeedback;
    public Renderer PlayerRenderer;
    public HealthManager HealthManager;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

