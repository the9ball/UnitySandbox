Shader "MyShader"
{
	Properties
	{
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float4 color : COLOR0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				fixed4 color : COLOR0;
				fixed4 check : COLOR1;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);

				// 間違ってるやつ
				o.color = fixed4(v.color.rgb, o.vertex.y);

				// 正しいやつ
				//o.color = fixed4(v.color.rgb, (1 - o.vertex.y) / 2);

				fixed x = o.vertex.y;
				//fixed x = (o.vertex.y + 1) / 2;
				//fixed x = (1 - o.vertex.y) / 2;

				o.check = fixed4(x, 0, 0, 1);
				//o.check = fixed4(x, x, x, 1);
				//o.check = fixed4(1, 1, 1, x);

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				//return i.check;
				return i.color;
			}
			ENDCG
		}
	}
}
