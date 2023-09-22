using JetBrains.Annotations;
using UnityEngine;

public sealed class LevelGenerator : MonoBehaviour, IInitializable
{
    [SerializeField] private Cube cubePrefab;

    private GameManager _gameManager;
    private Vector3 _offset;
    private Vector3 _position;
    [CanBeNull] private Cube _previousCube;

    public void Initialize(GameManager gameManager)
    {
        _gameManager = gameManager;
        _gameManager.Input.SubscribeToClick(OnClick);
        _offset = new Vector3(0, cubePrefab.transform.lossyScale.y + 0.05f, 0);
    }

    private void OnClick()
    {
        if (_gameManager.StateMachine.CurrentState != GameState.Game)
            return;


        if (_previousCube != null)
        {
            Destroy(_previousCube.CubeMover);

            if (!_previousCube.CubeCutter.Cut())
            {
                Debug.LogError("Cannot to cut the cube.");
                return;
            }
        }

        var cube = Instantiate(cubePrefab, _position, Quaternion.identity);
        cube.Init(_previousCube);

        _previousCube = cube;
        _position += _offset;
    }
}