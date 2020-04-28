Shader "Custom/foo" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "orange" {}
	    _Emission("Emission", float) = 0.92

	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			#pragma surface surf Lambert

			sampler2D _MainTex;
			float _Emission;

			struct Input {
				float2 uv_MainTex;
			};

			void surf(Input IN, inout SurfaceOutput o) {
				half4 c = tex2D(_MainTex, IN.uv_MainTex);
				o.Albedo = c.rgb;
				o.Alpha = c.a;
				o.Emission = c.rgb * tex2D(_MainTex, IN.uv_MainTex).a * _Emission;

			}
			ENDCG
	}
		FallBack "Diffuse"
}