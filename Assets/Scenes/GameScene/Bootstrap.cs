using R3;
using UnityEngine;
using VContainer;
using System;

public class Bootstrap : MonoBehaviour
{
    [Inject] private Fsm _fsm;

    private CompositeDisposable _disposables = new();

    private void Awake()
    { 
        _fsm.SetState<FsmStateSelection>();
    }

    private void OnDestroy()
    {
        _disposables.Dispose();
    }
}
