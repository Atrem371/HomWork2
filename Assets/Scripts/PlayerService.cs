using UnityEngine;
using MoreMountains.Feedbacks;
using Cinemachine;

public class PlayerService : MonoBehaviour {
    public static PlayerService Instance { get; private set; }

    [SerializeField] private HealthManager healthManager;
    [SerializeField] private Renderer[] playerRenderers;
    [SerializeField] private CinemachineImpulseSource impulseSource;
    [SerializeField] private MMF_Player blinkFeedback;

    public HealthManager HealthManager => healthManager;
    public Renderer[] PlayerRenderers => playerRenderers;
    public CinemachineImpulseSource ImpulseSource => impulseSource;
    public MMF_Player BlinkFeedback => blinkFeedback;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
}

















