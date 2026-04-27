using System;
public interface IReadOnlyObservableValue<T>
{
    T Value { get; }
    event Action<T> OnChanged;
}
