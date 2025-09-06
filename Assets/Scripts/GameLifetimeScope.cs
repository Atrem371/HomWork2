using UnityEngine;
using VContainer;
using VContainer.Unity;
using MoreMountains.Feedbacks;

public class GameLifetimeScope : LifetimeScope {
    [SerializeField] private MMF_Player blinkFeedback;
    [SerializeField] private Renderer playerRenderer;
    [SerializeField] private HealthManager healthManager;

    protected override void Configure(IContainerBuilder builder) {
        
        builder.RegisterInstance(blinkFeedback);
        builder.RegisterInstance(playerRenderer);
        builder.RegisterInstance(healthManager);
    }
}






