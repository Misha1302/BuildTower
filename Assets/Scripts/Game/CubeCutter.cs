namespace Game
{
    using System;

    public sealed class CubeCutter : CubeManipulation
    {
        public bool Cut(out float cutX)
        {
            cutX = float.NaN;

            var pos = transform.position;
            var scale = transform.localScale;

            if (DoesNotMakeSense(pos))
                return true;


            var delta = pos - point;

            if (Math.Abs(delta.x) > scale.x)
                return false;

            cutX = scale.x - (scale.x - (pos.x - point.x));
            pos.x -= delta.x / 2;
            scale.x -= Math.Abs(delta.x);

            transform.position = pos;
            transform.localScale = scale;
            return true;
        }
    }
}