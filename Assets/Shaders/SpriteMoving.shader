Shader "Sprites/Moving"
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
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 texColor = tex2D(_MainTex, i.uv) * i.color;
				fixed4 movingColor = tex2D(_MovingTex, i.uv * _Scale + _Direction * _Speed * _Time);
				clip(texColor.a);
				return texColor * movingColor;
			}
			ENDCG
		}
	}
}