using UnityEngine;

public sealed class CubeMover : MonoBehaviour
{
    [SerializeField] private Vector3 point0;
    [SerializeField] private Vector3 point1;
    [SerializeField] private float speed;
    private float _scaler;

    private float _time;

    private void Awake()
    {
        var pos = point1;
        pos.y = transform.position.y;
        // ReSharper disable once Unity.InefficientPropertyAccess
        transform.position = pos;


        _time = 1f;
        _scaler = 0.02f * speed;
    }

    private void Update()
    {
        var coefficient = Mathf.PingPong(_time, 1);
        var pos = Vector3.Lerp(point0, point1, coefficient);

        pos.y = transform.position.y;
        // ReSharper disable once Unity.InefficientPropertyAccess
        transform.position = pos;
    }

    private void FixedUpdate()
    {
        _time += _scaler;
    }
}