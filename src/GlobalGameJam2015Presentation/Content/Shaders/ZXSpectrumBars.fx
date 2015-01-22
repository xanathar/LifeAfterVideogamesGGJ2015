sampler TextureSampler : register(s0);
uniform extern float Time;
uniform extern float Rand;
Texture2D  myTex2D;
 
float4 PixelShaderFunction(float4 pos : SV_POSITION, float4 color1 : COLOR0, float2 texCoord : TEXCOORD0) : SV_TARGET0
{
	float4 tex = tex2D(TextureSampler, texCoord);

	if (pos.x > 200 && pos.y > 100 && pos.x < 1720 && pos.y < 980)
	{
		if (Time < 12.0)
		{
			return float4(0.7, 0.7, 0.7, 1.0);
		}
		else
		{
			float t = Time - 12.0;

			float minLine = floor(t);
			float proportion = (t - minLine) * 1080;

			float fY = floor(pos.y) % 8; 

			if ((fY < minLine) || (fY == minLine && (pos.y < proportion)))
			{
				tex.rgb = float3(0.0, 0.0, 0.0);
				tex.rgb = lerp(tex.rgb, float3(0.7, 0.7, 0.7), 1 - tex.a);
				return tex;
			}
			else
			{
				return float4(0.7, 0.7, 0.7, 1.0);
			}
		}
	}
	else
	{
		float looptime = (Time % 22.0);

		if (looptime < 10.0 && looptime >= 5.0)
		{
			if (((pos.y + (20 * Time)) % 100) < 50)
				return float4(0.0, 1.0, 1.0, 1.0);
			else
				return float4(1.0, 0.0, 0.0, 1.0);
		}
		else if (looptime < 12.0)
		{
			float floored = floor(looptime);

			if ((floored % 2) == 0)
				return float4(0.0, 1.0, 1.0, 1.0);
			else
				return float4(1.0, 0.0, 0.0, 1.0);
		}
		else
		{
			if (((pos.y + (20 * looptime) + Rand) % 50) < 25)
				return float4(1.0, 1.0, 0.0, 1.0);
			else
				return float4(0.0, 0.0, 1.0, 1.0);
		}
	}
}


technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_4_0 PixelShaderFunction();  
    }
}

