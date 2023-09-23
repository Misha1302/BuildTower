using System;
using JetBrains.Annotations;

public sealed class AlertField<T>
{
    [CanBeNull] public Action<T> actions;

    private T _value;

    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            actions?.Invoke(_value);
        }
    }
}