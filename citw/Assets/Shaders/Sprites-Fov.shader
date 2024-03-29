

// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Sprites/Fov"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
		_ForwardVec ("ForwardVec", Vector) = (0,0,0,1)
		_ObjWorldPos ("World Position", Vector) = (0,0,0,1)
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
        #include "UnitySprites.cginc"

        struct Input
        {
            float2 uv_MainTex;
            fixed4 color;
			float3 vWorldPos;
			float3 worldPos;
        };

		uniform float4 _ForwardVec;
		uniform float4 _ObjWorldPos;

        void vert (inout appdata_full v, out Input o)
        {
            v.vertex.xy *= _Flip.xy;

            #if defined(PIXELSNAP_ON)
            v.vertex = UnityPixelSnap (v.vertex);
            #endif

            UNITY_INITIALIZE_OUTPUT(Input, o);
			
			//o.worldPos = mul(unity_ObjectToWorld,float4(0,0,0,1));
			//
            o.color =  v.color * _Color * _RendererColor;
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
			
            fixed4 c = SampleSpriteTexture (IN.uv_MainTex) * IN.color;
           

			//_PosVec = float4(0,0,1,1);

			//float3 viewDir = UNITY_MATRIX_IT_MV[2].xyz;
			//float3 asd = UNITY_MATRIX_V[2].xyz;


			float3 wPos = IN.worldPos;
			wPos.z += wPos.y;
			wPos.y = 0;


			wPos = wPos - _ObjWorldPos;

			wPos = normalize(wPos);

			float ang = dot(_ForwardVec.xyz, wPos);
			float minDist = 2.0f;

			float dist = distance(IN.worldPos, _ObjWorldPos);
			float attenuationDistance = .5f;

			float maxAngle = 0.84f;

			if (ang > maxAngle) {
				
				o.Alpha = c.a;
				o.Albedo = c.rgb * c.a;




				
				
			}
			else if (dist < minDist) {
				//o.Albedo = c.rgb * c.a;
				//o.Alpha = c.a;

				float sata = ang * 100;

				float attenuation2 = max(0, 1 - ((maxAngle * 100) - sata) / 2);

				float attenuation = min((minDist - dist) * 1.5f, 1);
				o.Albedo = c.rgb * (c.a * min(1, (attenuation + attenuation2)));
				o.Alpha = (c.a * min(1,(attenuation + attenuation2)));
			}

			else {

				//o.Alpha = 0;
				//o.Albedo = c.rgb * 0;

				
				float sata = ang * 100;
				float attenuation = max(0, 1 - ((maxAngle * 100) - sata) / 2);

				
				if (dist > 2.0f) 
				{
					o.Alpha = 0;
					o.Albedo = c.rgb * (attenuation * c.a);


				} else {
					o.Alpha = c.a;
					o.Albedo = c.rgb * c.a;
				}
				
				
			}


			

			
			
        }
        ENDCG
    }


Fallback "Transparent/VertexLit"
}
