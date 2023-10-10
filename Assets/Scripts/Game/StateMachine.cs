namespace Game
{
    using UnityEngine;

    public sealed class StateMachine : MonoBehaviour, IInitializable
    {
        public readonly AlertField<GameState> currentState = new();

        public void Initialize(GameManager gameManager)
        {
            currentState.Value = GameState.Start;

            gameManager.Input.SubscribeToClick(() => currentState.Value = GameState.Game);
        }
    }
}