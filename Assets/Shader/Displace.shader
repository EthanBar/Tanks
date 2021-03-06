﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Shaders 102/Displace"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Displace ("Displace", 2D) = "white" {}
        _Mag("Mag", Range(0, 0.1)) = 1
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            sampler2D _Displace;
            sampler2D _MainTex;
            float _Mag;

            float4 frag (v2f i) : SV_Target
            {
                //float2 distuv = float2(i.uv.x + _Time.x * 2, i.uv.y + _Time.x * 2);
                float2 disp = tex2D(_Displace, i.uv).xy;
                disp = ((disp * 2) - 1) * ((_Mag/4 * _SinTime.a) + _Mag/1.5);

                float4 col = tex2D(_MainTex, i.uv + disp);
                //col *= float4(i.uv.x, i.uv.y, 0, 1);

                return col;
            }
            ENDCG
        }
    }
}