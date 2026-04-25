using R3;
using System;
using VContainer;

public class FsmStateSelection : FsmState
{
    [Inject] private CandidateGenerator _generator;
    [Inject] private SelectionView _view;
    private Person _hr;

    private IDisposable _selectSub;
    private IDisposable _refreshSub;

    public FsmStateSelection(Fsm fsm) : base(fsm) { }

    public override void Enter()
    {
        _view.Init();
        Refresh();

        _selectSub = _view.OnSelected.Subscribe(OnSelected);
        _refreshSub = _view.OnRefresh.Subscribe(_ => Refresh());
    }

    public override void Exit()
    {
        _selectSub?.Dispose();
        _refreshSub?.Dispose();

        _view.Hide();
        _view.Deinit();
    }
    public void Init(Person hr)
    {
        _hr = hr;
    }
    private void Refresh()
    {
        var list = _generator.GenerateList();
        _view.ShowCandidates(list);
    }

    private void OnSelected(Person model)
    {
    }
}
