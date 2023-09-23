using System;
using JetBrains.Annotations;
using UnityEngine;

public sealed class CubeCutter : MonoBehaviour
{
    private static readonly Vector3 _invalidVector3 = Vector3.positiveInfinity;
    private Vector3 _point;

    // ReSharper disable once InconsistentNaming
    private new Transform transform;

    public void Init([CanBeNull] Cube baseCube)
    {
        _point = baseCube != null
            ? baseCube.transform.position
            : _invalidVector3;

        transform = base.transform;
    }


    public bool Cut()
    {
        var pos = transform.position;
        var scale = transform.localScale;

        if (DoesNotMakeSense(pos))
            return true;


        var delta = pos - _point;

        if (Math.Abs(delta.x) > scale.x)
            return false;

        pos.x -= delta.x / 2;
        scale.x -= Math.Abs(delta.x);

        transform.position = pos;
        transform.localScale = scale;
        return true;
    }

    private bool DoesNotMakeSense(Vector3 pos) =>
        pos == _point
        // ReSharper disable CompareOfFloatsByEqualityOperator
        || _point.x == _invalidVector3.x
        || _point.y == _invalidVector3.y
        || _point.z == _invalidVector3.z;
}