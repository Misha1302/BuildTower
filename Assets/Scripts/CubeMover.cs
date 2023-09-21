using UnityEngine;

public sealed class CubeMover : MonoBehaviour
{
    [SerializeField] private Vector3 point0;
    [SerializeField] private Vector3 point1;
    [SerializeField] private float speed;

    private void Update()
    {
        var v = Mathf.PingPong(Time.time * speed, 1);
        var pos = Vector3.Lerp(point0, point1, v);
        pos.y = transform.position.y;
        transform.position = pos;
    }
}