namespace Game
{
    using Cinemachine.Utility;
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

            scale.x /= 2;
            cube.localScale = scale.Abs();

            var posOrNeg = scale.x < 0 ? -1 : 1;
            pos.x += posOrNeg * ((baseCube.transform.localScale / 2).x - posOrNeg * (cube.transform.localScale / 2).x);
            cube.position = pos;
        }
    }
}