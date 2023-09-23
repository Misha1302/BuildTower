using Unity.VisualScripting;
using UnityEngine;

public sealed class CubeShader : CubeManipulation
{
    public void Shade(float cutX)
    {
        var pos = transform.position;
        var scale = transform.localScale;

        scale.x = cutX;
        SpawnCube(pos, scale);
    }

    private void SpawnCube(Vector3 pos, Vector3 scale)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        cube.AddComponent<CubeShadow>();

        cube.localScale = scale;

        var pOrN = scale.x < 0 ? -1 : 1;
        pos.x += pOrN * ((baseCube.transform.localScale / 2).x - pOrN * (cube.transform.localScale / 2).x);
        cube.position = pos;
    }
}