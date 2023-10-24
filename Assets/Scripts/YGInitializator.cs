using UnityEngine;
using YG;

public sealed class YGInitializator : MonoBehaviour
{
    private void Awake()
    {
        // Проверяем запустился ли плагин
        if (YandexGame.SDKEnabled)
            // Если запустился, то запускаем Ваш метод
            GetData();
        // Если плагин еще не прогрузился, то метод не запуститься в методе Start,
        // но он запустится при вызове события GetDataEvent, после прогрузки плагина
    }

    // Подписываемся на событие GetDataEvent в OnEnable
    private void OnEnable() => YandexGame.GetDataEvent += GetData;

// Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

// Ваш метод, который будет запускаться в старте
    public void GetData()
    {
        // Получаем данные из плагина и делаем с ними что хотим
    }
}