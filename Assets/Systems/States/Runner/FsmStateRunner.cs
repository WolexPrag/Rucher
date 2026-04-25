using VContainer;

public class FsmStateRunner : FsmState
{
    [Inject] private RunnerView _view;
    public FsmStateRunner(Fsm fsm) : base(fsm)
    {
    }
}

