using VContainer;
using VContainer.Unity;

public class GameSceneInstaller : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {

        builder.Register<Fsm>(Lifetime.Singleton);

        builder.Register<FsmStateSelection>(Lifetime.Singleton);
        builder.Register<FsmStateBattle>(Lifetime.Singleton);
        builder.Register<FsmStateRunner>(Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<Bootstrap>();
        builder.RegisterComponentInHierarchy<SelectionView>();
        builder.RegisterComponentInHierarchy<BattleView>();
        builder.RegisterComponentInHierarchy<RunnerView>();

        builder.Register<NameGenerator>(Lifetime.Singleton);
        builder.Register<StatsGenerator>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<PersonGenerator>();

        builder.RegisterBuildCallback(resolver =>
        {
            var fsm = resolver.Resolve<Fsm>();

            fsm.AddState(resolver.Resolve<FsmStateSelection>());
            fsm.AddState(resolver.Resolve<FsmStateBattle>());
            fsm.AddState(resolver.Resolve<FsmStateRunner>());
        });



    }
}
