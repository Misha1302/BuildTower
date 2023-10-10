using System;
using UnityEngine;

public sealed class DataStorage
{
    private const string Money = "money";

    public long GetMoney() => ReadValue<long>(Money);
    public void SetMoney(long money) => SetValue(Money, money);

    private static T ReadValue<T>(string key)
    {
        if (typeof(T) == typeof(int))
            return (T)(object)PlayerPrefs.GetInt(key, -1);
        if (typeof(T) == typeof(float))
            return (T)(object)PlayerPrefs.GetFloat(key, Single.NaN);
        if (typeof(T) == typeof(string))
            return (T)(object)PlayerPrefs.GetString(key, null);
        if (typeof(T) == typeof(long))
            return (T)(object)long.Parse(PlayerPrefs.GetString(key, "-1"));
        if (typeof(T) == typeof(double))
            return (T)(object)double.Parse(PlayerPrefs.GetString(key, "NaN"));
        return ThrowHelper.ThrowInvalidOperationException<T>($"Unknown type {typeof(T)}");
    }

    private static void SetValue<T>(string key, T value)
    {
        if (typeof(T) == typeof(int))
            PlayerPrefs.SetInt(key, (int)(object)value);
        else if (typeof(T) == typeof(float))
            PlayerPrefs.SetFloat(key, (float)(object)value);
        else if (typeof(T) == typeof(string))
            PlayerPrefs.SetString(key, (string)(object)value);
        else if (typeof(T) == typeof(long))
            PlayerPrefs.SetString(key, value.ToString());
        else if (typeof(T) == typeof(double))
            PlayerPrefs.SetString(key, value.ToString());
        else ThrowHelper.ThrowInvalidOperationException($"Unknown type {typeof(T)}");
    }
}