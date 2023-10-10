namespace Game
{
    using TMPro;
    using UnityEngine;

    public sealed class UiManager : MonoBehaviour, IInitializable
    {
        [SerializeField] private TMP_Text gameScoreText;
        [SerializeField] private string gameFormatScoreText;

        private GameManager _gameManager;


        public void Initialize(GameManager gameManager)
        {
            _gameManager = gameManager;

            _gameManager.ScoreRepository.score.actions += _ => UpdateScore();

            UpdateScore();
        }

        private void UpdateScore()
        {
            gameScoreText.text = string.Format(gameFormatScoreText, _gameManager.ScoreRepository.ScoreForOnePlay);
        }
    }
}