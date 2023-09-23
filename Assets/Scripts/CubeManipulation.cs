using JetBrains.Annotations;
using UnityEngine;

public abstract class CubeManipulation : MonoBehaviour
{
    private static readonly Vector3 _invalidVector3 = Vector3.positiveInfinity;
    protected Cube baseCube;
    protected Vector3 point;
    protected new Transform transform;


    public void Init([CanBeNull] Cube bCube)
    {
        baseCube = bCube;
        point = bCube != null
            ? bCube.transform.position
            : _invalidVector3;

        transform = base.transform;
    }


    protected bool DoesNotMakeSense(Vector3 pos) =>
        pos == point
        // ReSharper disable CompareOfFloatsByEqualityOperator
        || point.x == _invalidVector3.x
        || point.y == _invalidVector3.y
        || point.z == _invalidVector3.z;
}