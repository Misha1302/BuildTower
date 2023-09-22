using UnityEngine;

public sealed class Cube : MonoBehaviour
{
    [SerializeField] private CubeMover cubeMover;

    public CubeCutter CubeCutter { get; private set; }
    public CubeMover CubeMover => cubeMover;

    private void Awake()
    {
        CubeCutter = gameObject.AddComponent<CubeCutter>();
    }

    public void Init(Cube previousCube)
    {
        if (previousCube != null)
            transform.localScale = previousCube.transform.localScale;

        CubeCutter.Init(previousCube);
    }
}