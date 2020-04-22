Shader "Custom/FurShader"
{
	   Properties{
        _MainTex("Base (RGB)", 2D) = "orange" {}
        _BumpMap("Normal Map", 2D) = "bump" {}
        _Emission("Emission", float) = 1.00

    }
        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 200

            CGPROGRAM
            #pragma surface surf WrapLambert
            
            float _Emission;

    half4 LightingWrapLambert (SurfaceOutput s, half3 lightDir, half atten) {
        half NdotL = dot (s.Normal, lightDir);
        half diff = NdotL * 0.5 + 0.5;
        half4 c;
        c.rgb = s.Albedo * _LightColor0.rgb * (diff * atten);
        c.a = s.Alpha;
        return c;
    }

    struct Input {
        float2 uv_MainTex;
        float2 uv_BumpMap;
    };
    
    sampler2D _MainTex;
    sampler2D _BumpMap;
    
    
    
        void surf (Input IN, inout SurfaceOutput o) 
        {
        o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
        o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
       
    }
    ENDCG

    }
        FallBack "Diffuse"
}