using Game;
using UnityEngine.SceneManagement;

public sealed class SceneManagerR : IInitializable
{
    public void Initialize(GameManager gameManager)
    {
        gameManager.StateMachine.currentState.actions += state =>
        {
            if (state == GameState.Lose)
                LoadGameOverScene();
        };
    }


    public static void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public static void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}