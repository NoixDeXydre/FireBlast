Shader "Custom/SharpUpscale"
{
    Properties
    {
        _MainTex ("Virtual Screen", 2D) = "white" {}
        _Sharpness ("Sharpness", Float) = 2.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_TexelSize; // x = 1/width, y = 1/height
            float _Sharpness;

            Varyings vert (Attributes IN)
            {
                Varyings OUT;
                OUT.pos = TransformObjectToHClip(IN.vertex.xyz);
                OUT.uv = IN.uv;
                return OUT;
            }

            float sharpen(float pix_coord, float resolution)
            {
                float norm = (frac(pix_coord) - 0.5) * 2.0;
                float norm2 = norm * norm;
                return floor(pix_coord) + norm * pow(norm2, _Sharpness) / 2.0 + 0.5;
            }

            half4 frag (Varyings IN) : SV_Target
            {
                float2 res = float2(1.0 / _MainTex_TexelSize.x, 1.0 / _MainTex_TexelSize.y);
                float2 uvSharpened;
                uvSharpened.x = sharpen(IN.uv.x * res.x, res.x) / res.x;
                uvSharpened.y = sharpen(IN.uv.y * res.y, res.y) / res.y;
                return tex2D(_MainTex, uvSharpened);
            }
            ENDHLSL
        }
    }
}