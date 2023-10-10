using System;
using JetBrains.Annotations;

public sealed class MoneyRepository : IInitializable
{
    [CanBeNull] public Action onMoneyChanged;

    private GameManager _gameManager;

    public long Money { get; private set; }
    public long MoneyForOnePlay { get; private set; }

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        Money = _gameManager.DataStorage.GetMoney();
        Money = Money < 0 ? 0 : Money;
        _gameManager.LevelGenerator.onCubeInstantiated += AddCoin;
    }

    public void AddMoney(long delta)
    {
        if (delta <= 0)
            ThrowHelper.ThrowArgumentOutOfRange(nameof(delta), delta);

        Money += delta;
        MoneyForOnePlay += delta;
        _gameManager.DataStorage.SetMoney(Money);
        onMoneyChanged?.Invoke();
    }

    public void ReduceMoney(long delta)
    {
        if (delta <= 0)
            ThrowHelper.ThrowArgumentOutOfRange(nameof(delta), delta);

        Money -= delta;
        _gameManager.DataStorage.SetMoney(Money);
        onMoneyChanged?.Invoke();
    }

    private void AddCoin() => AddMoney(1);
}