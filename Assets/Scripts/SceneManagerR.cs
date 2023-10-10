using UnityEngine.SceneManagement;

public static class SceneManagerR
{
    public static void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public static void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}