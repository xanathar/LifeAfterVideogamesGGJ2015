sampler TextureSampler : register(s0);
uniform extern float DoIt;
Texture2D  myTex2D;
 
float4 PixelShaderFunction(float4 pos : SV_POSITION, float4 color1 : COLOR0, float2 texCoord : TEXCOORD0) : SV_TARGET0
{
    float4 tex = tex2D(TextureSampler, texCoord);
	
	if (DoIt > 0.5)
	{
	    tex.rgb = dot(tex.rgb, float3(0.3, 0.59, 0.11));
	}

    return tex;
}


technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_4_0 PixelShaderFunction();  
    }
}

