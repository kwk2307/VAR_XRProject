#ifndef URPWATER_BLUR_INCLUDED
#define URPWATER_BLUR_INCLUDED

//#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

float _BlurStrength;

float3 BlendNormals(float3 A, float3 B)
{
	float3 t = A.xyz + float3(0.0, 0.0, 1.0);
	float3 u = B.xyz * float3(-1.0, -1.0, 1.0);
	return (t / t.z) * dot(t, u) - u;
}

struct appdataBlur
{
	float4 vertex : POSITION;
	float2 uv : TEXCOORD0;
};


struct v2fBlur
{
	float4 vertex : SV_POSITION;
	float2 uv : TEXCOORD0;
	float4 uvTap1 : TEXCOORD1;
	float4 uvTap2 : TEXCOORD2;
};

v2fBlur vertBlur(appdataBlur v)
{
	v2fBlur o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.uv = v.uv;

	float2 offset = _MainTex_TexelSize.xy * _BlurStrength;

	#ifdef BLUR_H
	offset *= float2(1, 0);
	#endif

	#ifdef BLUR_V
	offset *= float2(0, 1);
	#endif

	o.uvTap1.xy = v.uv + offset;
	o.uvTap1.zw = v.uv - offset;

	o.uvTap2.xy = v.uv + offset * 2;
	o.uvTap2.zw = v.uv - offset * 2;


	return o;
}

fixed4 fragBlur(v2fBlur i) : SV_Target
{
	// Blur Normal
	float4 r1 = tex2D(_MainTex, i.uvTap1.xy);
	float4 l1 = tex2D(_MainTex, i.uvTap1.zw);

	float4 r2 = tex2D(_MainTex, i.uvTap2.xy);
	float4 l2 = tex2D(_MainTex, i.uvTap2.zw);

	float3 blendR = BlendNormals(r1.rgb, r2.rgb);
	float3 blendL = BlendNormals(l1.rgb, l2.rgb);

	float3 compBlend = BlendNormals(blendR, blendL);

	float3 n = r1 + r2 + l1 + l2;
	n.xy *= 0.25;
	n.b = 0.5;

	return float4((n),1);
}

#endif