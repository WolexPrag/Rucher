using System;

public class ObservableValue<T> : IReadOnlyObservableValue<T>
{
    private T _value;
    public T Value
    {
        get => _value;
        set
        {
            if (Equals(_value, value)) return;
            _value = value;
            OnChanged?.Invoke(_value);
        }
    }
    public event Action<T> OnChanged;
    public ObservableValue(T initialValue)
    {
        _value = initialValue;
    }
    public ObservableValue()
    {
        _value = default;
    }
}