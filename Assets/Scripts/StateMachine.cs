using System;
using UnityEngine;

public sealed class StateMachine : MonoBehaviour, IStateMachine, IInitializable
{
    //TODO: choose lose state 
    private Action<GameState> _actions;
    private GameState _curState;

    public GameState CurrentState
    {
        get => _curState;
        private set
        {
            _curState = value;
            _actions?.Invoke(_curState);
        }
    }

    public void Initialize(GameManager gameManager)
    {
        CurrentState = GameState.Start;
        gameManager.Input.SubscribeToClick(OnClicked);
    }

    public void Subscribe(Action<GameState> onStateChanged)
    {
        _actions += onStateChanged;
    }

    public void UnSubscribe(Action<GameState> onStateChanged)
    {
        _actions -= onStateChanged;
    }

    private void OnClicked()
    {
        if (CurrentState == GameState.Start)
            CurrentState = GameState.Game;
    }
}