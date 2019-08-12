// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

#ifndef UNITY_SPRITES_INCLUDED
#define UNITY_SPRITES_INCLUDED

#include "UnityCG_2.cginc"

#ifdef UNITY_INSTANCING_ENABLED

    UNITY_INSTANCING_BUFFER_START(PerDrawSprite)
        // SpriteRenderer.Color while Non-Batched/Instanced.
        UNITY_DEFINE_INSTANCED_PROP(fixed4, unity_SpriteRendererColorArray)
        // this could be smaller but that's how bit each entry is regardless of type
        UNITY_DEFINE_INSTANCED_PROP(fixed2, unity_SpriteFlipArray)
    UNITY_INSTANCING_BUFFER_END(PerDrawSprite)

    #define _RendererColor  UNITY_ACCESS_INSTANCED_PROP(PerDrawSprite, unity_SpriteRendererColorArray)
    #define _Flip           UNITY_ACCESS_INSTANCED_PROP(PerDrawSprite, unity_SpriteFlipArray)

#endif // instancing

CBUFFER_START(UnityPerDrawSprite)
#ifndef UNITY_INSTANCING_ENABLED
    fixed4 _RendererColor;
    fixed2 _Flip;
#endif
    float _EnableExternalAlpha;
CBUFFER_END

// Material Color.
fixed4 _Color;

struct appdata_t
{
    float4 vertex   : POSITION;
    float4 color    : COLOR;
    float2 texcoord : TEXCOORD0;
    UNITY_VERTEX_INPUT_INSTANCE_ID
};

struct v2f
{
    float4 vertex   : SV_POSITION;
    fixed4 color    : COLOR;
    float2 texcoord : TEXCOORD0;
    UNITY_VERTEX_OUTPUT_STEREO
};

v2f SpriteVert(appdata_t IN)
{
    v2f OUT;

    UNITY_SETUP_INSTANCE_ID (IN);
    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);

#ifdef UNITY_INSTANCING_ENABLED
    IN.vertex.xy *= _Flip;
#endif

	

	if (IN.vertex.y >= 0) 
	{
		float3 camObjPos = mul(unity_WorldToObject, float4(_WorldSpaceCameraPos, 1));

		float size = 2;

		
		float3 extraOffset = float3(0, 0, 0); // float3(0, -0.28f, 0);
		extraOffset = float3(0, -0.58f, 0);
		camObjPos = -camObjPos;
		
		
		float3 temp = camObjPos;

		OUT.vertex = UnityObjectToClipPos((IN.vertex + temp + extraOffset) * 3);
		OUT.color = IN.color * float4(0,0,0,0) * _RendererColor;
	} 
	else
	{
		float3 realCamObjPos = mul(unity_WorldToObject, float4(_WorldSpaceCameraPos, 1));
		realCamObjPos.z = 0;

		float realCamDist = distance(realCamObjPos, float4(0,IN.vertex.y,0,1));

		OUT.vertex = UnityObjectToClipPos(IN.vertex);
		OUT.color = IN.color * float4(0,0,0, min(0.4f, 0.6f / (realCamDist * (realCamDist * .8f)))) * _RendererColor;
	}

    //OUT.vertex = UnityObjectToClipPos(IN.vertex + offset);

    OUT.texcoord = IN.texcoord;

	//float distMp = realCamDist;

    //OUT.color = IN.color * float4(0,0,0, (IN.vertex.y >= 0) ? 0 : min(0.3f, 0.3f / (realCamDist * (realCamDist * .4f)))) * _RendererColor;

    #ifdef PIXELSNAP_ON
    OUT.vertex = UnityPixelSnap (OUT.vertex);
    #endif

    return OUT;
}

sampler2D _MainTex;
sampler2D _AlphaTex;

fixed4 SampleSpriteTexture (float2 uv)
{
    fixed4 color = tex2D (_MainTex, uv);

#if ETC1_EXTERNAL_ALPHA
    fixed4 alpha = tex2D (_AlphaTex, uv);
    color.a = lerp (color.a, alpha.r, _EnableExternalAlpha);
#endif

    return color;
}

fixed4 SpriteFrag(v2f IN) : SV_Target
{
    fixed4 c = SampleSpriteTexture (IN.texcoord) * IN.color;
    c.rgb *= c.a;
    return c;
}

#endif // UNITY_SPRITES_INCLUDED
