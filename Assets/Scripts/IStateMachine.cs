using System;

public interface IStateMachine
{
    public void Subscribe(Action<GameState> onStateChanged);
    public void UnSubscribe(Action<GameState> onStateChanged);
}