Shader "gloomy/mutli_color_gloomy" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_PointOnePosition("Position of point one", Vector) = (0,0,0,0)
		_PointTwoPosition("Position of point two", Vector) = (0,0,0,0)
		_PointThreePosition("Position of point three", Vector) = (0,0,0,0)
		_PointFourPosition("Position of point four", Vector) = (0,0,0,0)
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
		fixed4 _PointOnePosition;
		fixed4 _PointTwoPosition;
		fixed4 _PointThreePosition;
		fixed4 _PointFourPosition;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		float get_distance(Input IN, float2 goal_point){
			float distance_one;
			float distance_two;

			//just calculate the distance
			distance_one = distance(IN.uv_MainTex, goal_point.xy);

			//here calculate what would be the distance when you
			//go over the border of the uv_tex
			if(IN.uv_MainTex.x > goal_point.x){
				goal_point = goal_point + (-1,0);
				distance_two = distance(IN.uv_MainTex, goal_point.xy);
			}else{
				distance_two = distance(IN.uv_MainTex, goal_point.xy);
			}

			//return the distance that is smaller
			if(distance_one > distance_two){
				return distance_two;
			}else{
				return distance_one;
			}
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			float p1_distance = distance(IN.uv_MainTex, _PointOnePosition.xy);
			float p2_distance = distance(IN.uv_MainTex, _PointTwoPosition.xy);
			float p3_distance = distance(IN.uv_MainTex, _PointThreePosition.xy);
			float p4_distance = distance(IN.uv_MainTex, _PointFourPosition.xy);

			// Albedo comes from a texture tinted by color
			fixed4 c = (tex2D (_MainTex, IN.uv_MainTex) 
				* _Color 
				+ float4(sqrt(p1_distance), 0, sqrt(p1_distance), 0)
				+ float4(0, sqrt(p2_distance), 0, 0)
				+ float4(sqrt(p3_distance), sqrt(p3_distance), 0, 0)
				+ float4(0, 0, sqrt(p4_distance), 0)) / 3;

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
