using System;
using JetBrains.Annotations;
using UnityEngine;

public sealed class CubeCutter : MonoBehaviour
{
    [CanBeNull] private Transform _baseCube;
    private Vector3 _point;

    // ReSharper disable once InconsistentNaming
    private new Transform transform;

    public void Init([CanBeNull] Transform baseCube)
    {
        _baseCube = baseCube;
        if (_baseCube != null) _point = _baseCube.position;
        transform = base.transform;
    }

    public void Cut()
    {
        CutX();
        CutY();

        var scale = transform.localScale;
        if (scale.x < 0)
            scale.x = 0;
        if (scale.z < 0)
            scale.z = 0;
    }

    private void CutX()
    {
        var pos = transform.position;
        var scale = transform.localScale;

        if (_baseCube == null || pos == _point)
            return;


        var delta = pos - _point;

        pos.x -= delta.x / 2;
        scale.x -= Math.Abs(delta.x);
        scale.x -= 4 - _baseCube.localScale.x;

        transform.position = pos;
        transform.localScale = scale;
    }

    private void CutY()
    {
        var pos = transform.position;
        var scale = transform.localScale;

        if (_baseCube == null || pos == _point)
            return;


        var delta = pos - _point;

        pos.z -= delta.z / 2;
        scale.z += -Math.Abs(delta.z);
        scale.z -= 4 - _baseCube.localScale.z;

        transform.position = pos;
        transform.localScale = scale;
    }
}