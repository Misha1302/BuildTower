using UnityEngine;

public static class StandardShaderUtils
{
    public enum BlendMode
    {
        Opaque,
        Cutout,
        Fade,
        Transparent
    }

    private static readonly int _srcBlend = Shader.PropertyToID("_SrcBlend");
    private static readonly int _dstBlend = Shader.PropertyToID("_DstBlend");
    private static readonly int _zWrite = Shader.PropertyToID("_ZWrite");

    public static void ChangeRenderMode(Material standardShaderMaterial, BlendMode blendMode)
    {
        switch (blendMode)
        {
            case BlendMode.Opaque:
                standardShaderMaterial.SetInt(_srcBlend, (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt(_dstBlend, (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt(_zWrite, 1);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = -1;
                break;
            case BlendMode.Cutout:
                standardShaderMaterial.SetInt(_srcBlend, (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt(_dstBlend, (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt(_zWrite, 1);
                standardShaderMaterial.EnableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 2450;
                break;
            case BlendMode.Fade:
                standardShaderMaterial.SetInt(_srcBlend, (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                standardShaderMaterial.SetInt(_dstBlend, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt(_zWrite, 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.EnableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
            case BlendMode.Transparent:
                standardShaderMaterial.SetInt(_srcBlend, (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt(_dstBlend, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt(_zWrite, 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
        }
    }
}