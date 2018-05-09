Shader "gloomy/mutli_color_gloomy" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_PointOnePosition("Position of point one", Vector) = (0,0,0,0)
		_PointTwoPosition("Position of point two", Vector) = (0,0,0,0)
		_PointThreePosition("Position of point three", Vector) = (0,0,0,0)
		_PointOneMask("Mask for point one", Vector) = (0,0,0,0)
		_PointTwoMask("Mask for point two", Vector) = (0,0,0,0)
		_PointThreeMask("Mask for point three", Vector) = (0,0,0,0)
		_Brigthness("Brigthness", Range(0.1, 2)) = 0.7
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		float4 _PointOnePosition;
		float4 _PointTwoPosition;
		float4 _PointThreePosition;
		float4 _PointOneMask;
		float4 _PointTwoMask;
		float4 _PointThreeMask;
		float _Brigthness;
		float4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		float get_distance(Input IN, float4 goal_point){
			float distance_one;
			float distance_two;

			//just calculate the distance
			distance_one = distance(IN.uv_MainTex, goal_point.xy);

			//here calculate what would be the distance when you
			//go over the border of the uv_tex
			float isSmaller = step(IN.uv_MainTex.x, goal_point.x);
			float plus_direction = distance(IN.uv_MainTex, float2(goal_point.x + 1, goal_point.y)) * (1 - isSmaller);
			float minus_direction = distance(IN.uv_MainTex, float2(goal_point.x - 1, goal_point.y)) * isSmaller;
			distance_two = max(plus_direction, minus_direction);
			// the above code is the same as this:
			// if(IN.uv_MainTex.x < goal_point.x){
			// 	distance_two = distance(IN.uv_MainTex, float2(goal_point.x - 1, goal_point.y));
			// }else{
			// 	distance_two = distance(IN.uv_MainTex, float2(goal_point.x + 1, goal_point.y));
			// }

			return min(distance_one, distance_two);
		}

		float4 applyPoint(Input IN, float4 position, float4 mask){
			float distance = get_distance(IN, position);

			float4 color_distance = float4(
				1 - distance,
				1 - distance,
			    1 - distance,
				0
			);
			// apply mask
			color_distance = color_distance * mask;

			return color_distance * _Brigthness;
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			float4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			c = c + applyPoint(IN, _PointOnePosition, _PointOneMask);
			c = c + applyPoint(IN, _PointTwoPosition, _PointTwoMask);
			c = c + applyPoint(IN, _PointThreePosition, _PointThreeMask);

			// Albedo comes from a texture tinted by color
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}

		ENDCG
	}
	FallBack "Diffuse"
}
