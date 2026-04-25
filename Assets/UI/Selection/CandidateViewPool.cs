using System.Collections.Generic;
using UnityEngine;

public class CandidateViewPool
{
    private readonly CandidateView _prefab;
    private readonly Transform _parent;

    private readonly Stack<CandidateView> _pool = new();

    public CandidateViewPool(CandidateView prefab, Transform parent)
    {
        _prefab = prefab;
        _parent = parent;
    }

    public CandidateView Get()
    {
        if (_pool.Count > 0)
        {
            var view = _pool.Pop();
            view.gameObject.SetActive(true);
            return view;
        }

        return Object.Instantiate(_prefab, _parent);
    }

    public void Release(CandidateView view)
    {
        view.gameObject.SetActive(false);
        _pool.Push(view);
    }
}
