using System;
using UnityEngine;

public sealed class CubeCutter : MonoBehaviour
{
    //TODO: init from gameManager
    [SerializeField] private Transform baseCube;
    private Vector3 _point;

    // ReSharper disable once InconsistentNaming
    private new Transform transform;

    private void Start()
    {
        _point = baseCube.position;
        transform = base.transform;

        CutX();
        CutY();
    }

    public void CutX()
    {
        var pos = transform.position;
        var scale = transform.localScale;

        if (pos == _point)
            return;


        var delta = pos - _point;

        pos.x -= delta.x / 2;
        scale.x -= Math.Abs(delta.x);
        scale.x -= 4 - baseCube.localScale.x;

        transform.position = pos;
        transform.localScale = scale;
    }

    public void CutY()
    {
        var pos = transform.position;
        var scale = transform.localScale;

        if (pos == _point)
            return;


        var delta = pos - _point;

        pos.z -= delta.z / 2;
        scale.z += -Math.Abs(delta.z);
        scale.z -= 4 - baseCube.localScale.z;

        transform.position = pos;
        transform.localScale = scale;
    }
}