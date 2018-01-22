Shader "Surf_NormalInVS" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
    }

    Category {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
        Cull Off ZWrite Off

        SubShader {

            CGPROGRAM
            #pragma surface surf Lambert alpha vertex:vert

            sampler2D _MainTex;
            fixed4 _TintColor;

            void vert (inout appdata_full v)
            {
                // MUST assign normal in vs, for compatibility
                // OpenGL 3.3 & 4.1 don't light otherwise in Unity 2017.3
                v.normal = float3(0,0,-1);
            }

            struct Input {
                float2 uv_MainTex;
                fixed4 vertexColour : COLOR;
            };

            void surf (Input IN, inout SurfaceOutput o) {
                fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
                o.Albedo = 2.0 * IN.vertexColour * c.rgb;
                o.Alpha = 2.0 * IN.vertexColour.a * c.a;
                // Generating the Normal here is bad in Unity 2017.3
                //o.Normal = float3(0,0,-1);
            }
            ENDCG
        }
    }
}
