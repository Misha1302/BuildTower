namespace Game
{
    public sealed class ScoreRepository : IInitializable
    {
        private GameManager _gameManager;

        public readonly AlertField<long> score = new();

        public long ScoreForOnePlay { get; private set; }

        public long BestScore
        {
            get => _gameManager.DataStorage.GetBestScore();
            private set => _gameManager.DataStorage.SetBestScore(value > BestScore ? value : BestScore);
        }

        public void Initialize(GameManager gameManager)
        {
            _gameManager = gameManager;
            score.Value = _gameManager.DataStorage.GetScore();
            score.Value = score.Value < 0 ? 0 : score.Value;
            _gameManager.LevelGenerator.onCubeInstantiated += AddCoin;

            score.actions += value => _gameManager.DataStorage.SetScore(value);
        }

        public void AddScore(long delta)
        {
            if (delta <= 0)
                ThrowHelper.ThrowArgumentOutOfRange(nameof(delta), delta);

            ScoreForOnePlay += delta;
            BestScore = ScoreForOnePlay;
            score.Value += delta;
        }

        public void ReduceScore(long delta)
        {
            if (delta <= 0)
                ThrowHelper.ThrowArgumentOutOfRange(nameof(delta), delta);

            score.Value -= delta;
        }

        private void AddCoin() => AddScore(1);
    }
}