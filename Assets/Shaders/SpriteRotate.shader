Shader "Sprites/Rotate"
{
	Properties
	{
		[PerRendererData] _MainTex("Main Texture", 2D) = "white" {}
		_MovingTex("Moving Texture", 2D) = "white" {}
		_Color("Color" , Color) = (1,1,1,1)
		_Speed("Speed" , Float) = 0
		_Direction("Direction" , Vector) = (0, 0, 0, 0)
		_Scale("Scale" , Vector) = (0, 0, 0, 0)
	}

	SubShader
	{
		Tags
		{
			"RenderType" = "Transparent"
			"Queue" = "Transparent"
		}

		Cull Off
		Blend SrcAlpha OneMinusSrcAlpha

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
				float4 color : COLOR;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				float4 color : COLOR;
			};

			fixed4 _Color;
			sampler2D _MainTex;
			sampler2D _MainTex_ST;
			sampler2D _MovingTex;
			float _Speed;
			Vector _Direction;
			Vector _Scale;

			v2f vert(appdata v)
			{
				v2f o;
				o.uv = v.uv;
				o.color = v.color;
				o.vertex = UnityObjectToClipPos(v.vertex);

				const float Deg2Rad = (UNITY_PI * 2.0) / 360.0;

				float rotationRadians = /*_Rotation **//* Deg2Rad * */_Speed * _Time; // convert degrees to radians
				float s = sin(rotationRadians); // sin and cos take radians, not degrees
				float c = cos(rotationRadians);

				float2x2 rotationMatrix = float2x2(c, -s, s, c); // construct simple rotation matrix

				o.uv -= 0.5; // offset UV so we rotate around 0.5 and not 0.0
				o.uv = mul(rotationMatrix, o.uv); // apply rotation matrix
				o.uv += 0.5; // offset UV again so UVs are in the correct location

				//o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 texColor = tex2D(_MainTex, i.uv) * i.color;
				clip(texColor.a);
				return texColor;
			}
			ENDCG
		}
	}
}