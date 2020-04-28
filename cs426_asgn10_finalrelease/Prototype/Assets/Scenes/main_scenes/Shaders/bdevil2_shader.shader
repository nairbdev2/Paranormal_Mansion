/*
 * name: Brian De Villa
 * Shader: Custom/bdevil2_shader
 * Note: Testing Rim Lighting Shader (Testing)
 * 
 */

Shader "Custom/bdevil2_shader"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_BumpMap("Normal Map", 2D) = "bump" {}
		_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power: ", Range(1.0,8.0)) = 3.0

		// Emission
		//_Emission("Emission", Float) = 0
		_Color("Emission Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        // Use shader model 3.0 target, to get nicer looking lighting
        // #pragma target 3.0

        struct Input
        {
			float4 color : Color;
            float2 uv_MainTex;
			float2 uv_BumpMap;
			float3 viewDir;
        };

		sampler2D _MainTex;
		sampler2D _BumpMap;
		float4 _RimColor;
		float _RimPower;
		//float _Emission;
		fixed4 _Color;

		void surf(Input IN, inout SurfaceOutput o) {

			IN.color = _Color;
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * IN.color;
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = _RimColor.rgb * pow(rim, _RimPower);
			//o.Emission = (tex2D(_MainTex, IN.uv_MainTex).rgb * _Color) * tex2D(_MainTex, IN.uv_MainTex).a * _Emission;
		}
        ENDCG
    }
    FallBack "Diffuse"
}
