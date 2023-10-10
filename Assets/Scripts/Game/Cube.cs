namespace Game
{
    using UnityEngine;

    public sealed class Cube : MonoBehaviour
    {
        [SerializeField] private CubeMover cubeMover;
        [SerializeField] private CubeShader cubeShader;

        public CubeCutter CubeCutter { get; private set; }
        public CubeMover CubeMover => cubeMover;
        public CubeShader CubeShader => cubeShader;

        private void Awake()
        {
            CubeCutter = gameObject.AddComponent<CubeCutter>();
        }

        public void Init(Cube previousCube)
        {
            if (previousCube != null)
                transform.localScale = previousCube.transform.localScale;

            CubeCutter.Init(previousCube);
            CubeShader.Init(previousCube);
        }
    }
}