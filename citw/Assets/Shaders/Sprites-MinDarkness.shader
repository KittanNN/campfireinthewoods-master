// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Sprites/MinDarkness"
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
			
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

        CGPROGRAM
        #pragma surface surf Lambert vertex:vert nofog nolightmap nodynlightmap keepalpha noinstancing
        #pragma multi_compile _ PIXELSNAP_ON
        #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
        #include "UnitySprites.cginc"

        struct Input
        {
            float2 uv_MainTex;
            fixed4 color;
			float3 worldPos;
        };

        void vert (inout appdata_full v, out Input o)
        {
            v.vertex.xy *= _Flip.xy;

            #if defined(PIXELSNAP_ON)
            v.vertex = UnityPixelSnap (v.vertex);
            #endif

            UNITY_INITIALIZE_OUTPUT(Input, o);
			
			//o.worldPos = mul(unity_ObjectToWorld, v.vertex);

            o.color =  v.color * _Color * _RendererColor;
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
			
            fixed4 c = SampleSpriteTexture (IN.uv_MainTex) * IN.color;
            

			float3 vertTemp = IN.worldPos;
			vertTemp.z += vertTemp.y;

			vertTemp.y = 0;

			float3 tempVec = _WorldSpaceCameraPos.xyz;
			tempVec.z += tempVec.y + 0.3f;
			tempVec.y = 0;
			float camDist = distance(vertTemp, tempVec);
			//float camDistx = distance(vertTemp.x, tempVec.x);
			//float camDisty = distance(vertTemp.z, tempVec.z);

			//camDisty = (camDistx >= 2) ? camDisty : 0;
			//float newAlpha =  
			//o.Alpha = min(c.a , (camDist * camDist) / 4);
			o.Alpha = min(c.a, max(0.6f / max((IN.worldPos.y * 3.8f), 0.9f), (camDist * (camDist / 2) * (camDist / 2) * (camDist / 2)) / 2));
            //o.Alpha = min(c.a, (camDist * camDist * camDist * camDist) / 2);
			o.Albedo = c.rgb * c.a; //() * newAlpha;
			
        }
        ENDCG
    }


Fallback "Transparent/VertexLit"
}
