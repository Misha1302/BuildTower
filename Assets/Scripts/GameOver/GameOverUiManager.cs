namespace GameOver
{
    using TMPro;
    using UnityEngine;

    public sealed class GameOverUiManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text bestScoreText;
        [SerializeField] private TMP_Text totalScoreText;

        [SerializeField] private string scoreTextFormat;
        [SerializeField] private string bestScoreTextFormat;
        [SerializeField] private string totalScoreTextFormat;

        private void Start()
        {
            scoreText.text = string.Format(scoreTextFormat, DataTransfer.Data["current score"]);
            bestScoreText.text = string.Format(bestScoreTextFormat, DataTransfer.Data["best score"]);
            totalScoreText.text = string.Format(totalScoreTextFormat, DataTransfer.Data["total score"]);
        }
    }
}