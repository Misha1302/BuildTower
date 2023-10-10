using System;
using System.Runtime.CompilerServices;

public static class ThrowHelper
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object ThrowArgumentOutOfRange(string argName, object obj) =>
        ThrowArgumentOutOfRange<object>(argName, obj);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static T ThrowArgumentOutOfRange<T>(string argName, object obj) =>
        throw new ArgumentOutOfRangeException(argName, obj.ToString());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object ThrowInvalidOperationException(object obj) =>
        ThrowInvalidOperationException<object>(obj);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static T ThrowInvalidOperationException<T>(object obj) =>
        throw new InvalidOperationException(obj.ToString());
}