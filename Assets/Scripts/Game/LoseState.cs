namespace Game
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    public sealed class LoseState : MonoBehaviour, IInitializable
    {
        [SerializeField] private Image loseImage;
        [SerializeField] private float speed;

        public void Initialize(GameManager gameManager)
        {
            gameManager.StateMachine.currentState.actions += state =>
            {
                if (state == GameState.Lose)
                    StartCoroutine(Lose());
            };
        }

        private IEnumerator Lose()
        {
            while (loseImage.color.a < 1)
            {
                var color = loseImage.color;
                color.a += 1 / speed * Time.deltaTime;
                loseImage.color = color;

                yield return new WaitForEndOfFrame();
            }

            SceneManagerR.LoadGameOverScene();
        }
    }
}