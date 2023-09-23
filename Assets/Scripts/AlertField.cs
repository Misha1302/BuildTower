using System;
using System.Collections.Generic;
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
            if (EqualityComparer<T>.Default.Equals(_value, value))
                return;

            _value = value;
            actions?.Invoke(_value);
        }
    }
}