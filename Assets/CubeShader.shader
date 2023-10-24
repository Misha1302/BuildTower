Shader "Custom/CubeShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Color2 ("Color 2", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Coefficient ("Coefficient", Range(0, 30)) = 1
        _Y ("Y", Range(0, 1)) = 0.5
        _Speed ("Speed", Range(0, 10)) = 1
        _Offset ("Offset", Range(-10, 10)) = 1
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 screenPos;
            float3 worldPos : TEXCOORD0;
        };

        half _Glossiness;
        fixed _Coefficient;
        fixed _Offset;
        fixed _Y;
        fixed _Speed;
        half _Metallic;
        fixed4 _Color;
        fixed4 _Color2;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
        // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            if (IN.screenPos.y < _Y)
            {
                fixed4 c = lerp(_Color2, _Color, smoothstep(0, 1, sin(_Time.y * _Speed + IN.worldPos.y * _Coefficient)));
                o.Albedo = c.rgb;
            }
            else
            {
                o.Albedo = _Color2;
            }
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
        }
        ENDCG
    }
    FallBack "Diffuse"
}