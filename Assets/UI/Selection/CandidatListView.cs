using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using R3;

public class CandidateListView : MonoBehaviour
{
    private Subject<Person> _onCandidateSelected = new();
    public Observable<Person> OnCandidateSelected => _onCandidateSelected;

    [SerializeField] private CandidateView _candidatePrefab;
    [SerializeField] private Transform _container;

    private CandidateViewPool _pool;
    private readonly List<CandidateView> _activeViews = new();

    public void ShowCandidates(List<Person> candidates)
    {
        if(_pool == null)
        {
            _pool = new(_candidatePrefab,_container);
        }
        gameObject.SetActive(true);

        ClearActive();

        foreach (var model in candidates)
        {
            var view = _pool.Get();
            view.Bind(model);
            view.OnClicked += HandleCandidateClicked;
            _activeViews.Add(view);
        }
    }

    private void HandleCandidateClicked(Person model)
    {
        _onCandidateSelected.OnNext(model);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Deinit()
    {
        foreach (var view in _activeViews)
            view.OnClicked -= HandleCandidateClicked;

        ClearActive();

        _onCandidateSelected.OnCompleted();
        _onCandidateSelected = new Subject<Person>();

    }

    private void ClearActive()
    {
        foreach (var view in _activeViews)
        {
            view.OnClicked -= HandleCandidateClicked;
            _pool.Release(view);
        }

        _activeViews.Clear();
    }
}
