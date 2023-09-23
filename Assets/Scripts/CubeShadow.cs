using UnityEngine;

public sealed class CubeShadow : MonoBehaviour
{
    private readonly Vector3 _translation = Vector3.down * 0.02f;
    private Material _material;

    private void Start()
    {
        _material = transform.GetComponent<Renderer>().material;
        StandardShaderUtils.ChangeRenderMode(_material, StandardShaderUtils.BlendMode.Transparent);
    }

    private void FixedUpdate()
    {
        transform.Translate(_translation);

        var materialColor = _material.color;
        if (materialColor.a > 0)
            materialColor.a -= 0.02f;
        else
            Destroy(gameObject);

        _material.color = materialColor;
    }
}