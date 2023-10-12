namespace Game
{
    using UnityEngine;

    public sealed class LoseState : MonoBehaviour, IInitializable
    {
        public void Initialize(GameManager gameManager)
        {
            gameManager.StateMachine.currentState.actions += state =>
            {
                if (state == GameState.Lose)
                    StartCoroutine(
                        GetComponent<ImageAnimator>().Animate(SceneManagerR.LoadGameOverScene)
                    );
            };
        }
    }
}