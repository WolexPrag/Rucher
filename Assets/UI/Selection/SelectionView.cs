using UnityEngine;
using UnityEngine.UI;
using R3;
using System;
using System.Collections.Generic;

public class SelectionView : View
{
    [SerializeField] private CandidateListView _listView;
    [SerializeField] private Button _refreshButton;

    private Subject<Person> _onSelected = new();
    public Observable<Person> OnSelected => _onSelected;

    private Subject<Unit> _onRefresh = new();
    public Observable<Unit> OnRefresh => _onRefresh;

    private IDisposable _selectSub;

    public override void Init()
    {
        _selectSub = _listView.OnCandidateSelected
            .Subscribe(model => _onSelected.OnNext(model));

        _refreshButton.onClick.AddListener(() =>
        {
            _onRefresh.OnNext(Unit.Default);
        });
    }

    public void ShowCandidates(List<Person> candidates)
    {
        Show();
        _listView.ShowCandidates(candidates);
    }

    public override void Deinit()
    {
        _listView.Deinit();

        _onSelected.OnCompleted();
        _onSelected = new Subject<Person>();

        _onRefresh.OnCompleted();
        _onRefresh = new Subject<Unit>();

        _selectSub?.Dispose();
    }
}
