using UnityEngine;

public sealed class CubeShadow : MonoBehaviour
{
    private readonly Vector3 _translation = Vector3.down;
    private Material _material;

    private void Start()
    {
        _material = transform.GetComponent<Renderer>().material;
        StandardShaderUtils.ChangeRenderMode(_material, StandardShaderUtils.BlendMode.Transparent);
    }

    private void Update()
    {
        transform.Translate(_translation * Time.deltaTime);

        var materialColor = _material.color;
        if (materialColor.a > 0)
            materialColor.a -= Time.deltaTime;
        else
            Destroy(gameObject);

        _material.color = materialColor;
    }
}