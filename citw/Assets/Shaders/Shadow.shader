// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Sprites/Shadow"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor ("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip ("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha ("Enable External Alpha", Float) = 0
    }

    SubShader
    {

        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
			"DisableBatching"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        CGPROGRAM
        #pragma surface surf Lambert vertex:vert nofog nolightmap nodynlightmap keepalpha noinstancing
        #pragma multi_compile _ PIXELSNAP_ON
        #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
        #include "UnitySprites_2.cginc"

        struct Input
        {
            float2 uv_MainTex;
            fixed4 color;
        };


        void vert (inout appdata_full v, out Input o)
        {
            v.vertex.xy *= _Flip.xy;



            #if defined(PIXELSNAP_ON)
            v.vertex = UnityPixelSnap (v.vertex);
            #endif

            UNITY_INITIALIZE_OUTPUT(Input, o);


			if (v.vertex.y >= 0)
			{
				float3 camObjPos = mul(unity_WorldToObject, float4(_WorldSpaceCameraPos, 1));

				float size = 2;


				float3 extraOffset = float3(0, 0, 0); // float3(0, -0.78f, 0);
				extraOffset = float3(0, -0.48f, 0);
				camObjPos = -camObjPos;

				



				float3 temp = camObjPos;
				v.vertex.xy += (temp.xy + extraOffset.xy ) * 2;
				


				//(IN.vertex + temp + extraOffset) * 2
				//OUT.vertex = UnityObjectToClipPos();
				//OUT.color = IN.color * float4(0, 0, 0, 0) * _RendererColor;
				o.color = v.color * float4(0, 0, 0, 0) * _RendererColor;
			}
			else
			{

				float3 realCamObjPos = mul(unity_WorldToObject, float4(_WorldSpaceCameraPos, 1));
				realCamObjPos.z = 0;
				//v.vertex.xy += (float3(0.1f,0.1f,0.1f)) * 2;
				float realCamDist = distance(realCamObjPos, float4(v.vertex.x, v.vertex.y, 0, 1));

				o.color = v.color * float4(0, 0, 0, min(0.3f, 0.3f / (realCamDist * (realCamDist * .8f)))) * _RendererColor;
			} // min(0.6f, 0.6f / (realCamDist * (realCamDist * .8f)))


			
				
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = SampleSpriteTexture (IN.uv_MainTex) * IN.color;
            o.Albedo = c.rgb * c.a;
            o.Alpha = c.a;
        }
        ENDCG
    }

//Fallback "Transparent/VertexLit"
}

