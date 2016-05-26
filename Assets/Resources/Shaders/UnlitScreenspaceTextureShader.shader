Shader "Custom/UnlitScreenspaceTextureShader"
{
	Properties
	{
		_Color("color",color) = (1,1,1,1)
		_PatternColor("pattern color",color) = (1,1,1,1)
		_PatternTex("texture",2D) = "white" {}
		
		_HeightMin("height min",float) = -1
	    _HeightMax("height max",float) = 1
	    _ColorMin("tint color min",color) = (0,0,0,1)
	    _ColorMax("tint color max",color) = (1,1,1,1)
	    
	    _TilingFactor("tiling factor",float) = 1
	    _ScrollSpeedX("scrolling speed x",float) = 0
	    _ScrollSpeedY("scrolling speed y",float) = 0
	    _PatternOpacity("pattern opacity",float) = .025
	}

	SubShader
	{
		Tags
		{
			"Queue" = "Geometry"
			"RenderType" = "Transparent"
		}
		
		Cull back
		Blend SrcAlpha OneMinusSrcAlpha
		zWrite on
		Lighting off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma multi_compile_fog
			#pragma target 3.0

			#include "UnityCG.cginc"

			fixed4 _Color;
			fixed4 _PatternColor;
			
			fixed4 _ColorMin;
		    fixed4 _ColorMax;
		    float _HeightMin;
		    float _HeightMax;
     		
     		sampler2D _PatternTex;
     		
     		float _TilingFactor;
     		float _ScrollSpeedX;
     		float _ScrollSpeedY;
     		float _PatternOpacity;
     
			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 localPos : TEXCOORD0;
				float4 screenPos : TEXCOORD1;
			};
			
			float4 _PatternTex_ST;
			
			v2f vert ( appdata_base v )
			{
				v2f o;
				UNITY_INITIALIZE_OUTPUT(v2f,o);
			    
				o.vertex = mul(UNITY_MATRIX_MVP,v.vertex);
			    o.localPos = v.vertex.xyz;
			    o.screenPos = ComputeScreenPos(o.vertex);
			    
				return o;
			}

			fixed4 frag ( v2f i ) : COLOR
			{
				// Get base color
				fixed4 col = _Color;

				// Local vertex height
				fixed h = (_HeightMax - i.localPos.y) / (_HeightMax - _HeightMin);
				fixed4 tintCol = lerp(_ColorMax.rgba,_ColorMin.rgba,h);
				
				// Apply gradient
				fixed4 gradientCol = col * tintCol;
				
				// Pattern tiling
				fixed2 uv2 = (i.screenPos.xy / i.screenPos.w) * _TilingFactor;
				
				// Scale correction
				uv2.x *= 2.25;
				
				// Pattern scrolling
				fixed2 scrollingSpeed = float2(_ScrollSpeedX,_ScrollSpeedY);
				uv2.xy += (scrollingSpeed * _Time);
				
				// Apply pattern color
				fixed4 texCol = tex2D(_PatternTex,uv2).a * _PatternOpacity;
				texCol *= _PatternColor;

				// Define final color
				fixed4 finalCol = gradientCol;
				finalCol.rgb += texCol.rgb;
				
				return finalCol;
			}
			ENDCG
		}
	}
}
