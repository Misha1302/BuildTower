using JetBrains.Annotations;
using UnityEngine;

public sealed class LevelGenerator : MonoBehaviour, IInitializable
{
    [SerializeField] private Cube cubePrefab;

    private GameManager _gameManager;
    [CanBeNull] private Cube _previousCube;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        _gameManager.Input.SubscribeToClick(OnClick);
        _gameManager.GameDataManager.cubeOffset.Value = new Vector3(0, cubePrefab.transform.lossyScale.y + 0.05f, 0);
    }

    private void OnClick()
    {
        if (_gameManager.StateMachine.currentState.Value != GameState.Game)
            return;


        if (_previousCube != null)
        {
            Destroy(_previousCube.CubeMover);

            if (!_previousCube.CubeCutter.Cut())
            {
                _gameManager.StateMachine.currentState.Value = GameState.Lose;
                Debug.LogError("Cannot to cut the cube.");
                return;
            }
        }

        var cube = Instantiate(cubePrefab, _gameManager.GameDataManager.nextCubePosition.Value, Quaternion.identity);
        cube.Init(_previousCube);

        _previousCube = cube;
        _gameManager.GameDataManager.nextCubePosition.Value += _gameManager.GameDataManager.cubeOffset.Value;
    }
}