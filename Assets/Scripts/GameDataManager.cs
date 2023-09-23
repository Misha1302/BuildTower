using UnityEngine;

public sealed class GameDataManager
{
    public readonly AlertField<Vector3> nextCubePosition = new();
    public readonly AlertField<Vector3> cubeOffset = new();
}