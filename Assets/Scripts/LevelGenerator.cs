using System;
using JetBrains.Annotations;
using UnityEngine;

public sealed class LevelGenerator : MonoBehaviour, IInitializable
{
    [SerializeField] private Cube cubePrefab;

    private GameManager _gameManager;
    [CanBeNull] private Cube _previousCube;

    [CanBeNull] public Action onCubeInstantiated;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        _gameManager.Input.SubscribeToClick(OnClick);
        _gameManager.GameDataManager.cubeOffset.Value = new Vector3(0, cubePrefab.transform.lossyScale.y + 0.05f, 0);


        _previousCube = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
        _previousCube!.transform.position = _previousCube.CubeMover.GetLerp(0.5f);

        _gameManager.GameDataManager.nextCubePosition.Value += _gameManager.GameDataManager.cubeOffset.Value;
        Destroy(_previousCube.CubeMover);
        Destroy(_previousCube.CubeCutter);
        Destroy(_previousCube.CubeShader);
    }

    private void OnClick()
    {
        if (_gameManager.StateMachine.currentState.Value != GameState.Game)
            return;


        if (_previousCube != null
            && _previousCube.CubeMover != null
            && _previousCube.CubeCutter != null
            && _previousCube.CubeShader != null)
        {
            Destroy(_previousCube.CubeMover);

            if (!_previousCube.CubeCutter.Cut(out var cutX))
            {
                _gameManager.StateMachine.currentState.Value = GameState.Lose;
                Debug.LogError("Cannot to cut the cube.");
                return;
            }

            if (!float.IsNaN(cutX))
                _previousCube.CubeShader.Shade(cutX);
        }

        var cube = Instantiate(cubePrefab, _gameManager.GameDataManager.nextCubePosition.Value, Quaternion.identity);
        cube.Init(_previousCube);

        _previousCube = cube;
        _gameManager.GameDataManager.nextCubePosition.Value += _gameManager.GameDataManager.cubeOffset.Value;

        onCubeInstantiated?.Invoke();
    }
}