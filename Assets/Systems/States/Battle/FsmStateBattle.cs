using VContainer;

public class FsmStateBattle : FsmState
{
    [Inject] private BattleView _view;
    private Person _hr;
    private Person _candidate;

    public FsmStateBattle(Fsm fsm) : base(fsm) { }

    public void Init(Person candidate,Person hr)
    {
        _candidate = candidate;
        _hr = hr;
    }

    public override void Enter()
    {

    }

}
