Shader "Stagit/StagitCloudShader" {

      //Earth Shader created by Julien Lynge @ Fragile Earth Studios
      //Upgrade of a shader originally put together in Strumpy Shader Editor by Clamps
      //Feel free to use and share this shader, but please include this attribution

      Properties 
      {
    	_MainTex("Base (RGB) Trans (A)", 2D) = "black" {}
    	_Brightness ("Main Brightness", Range (0.5, 2.5)) = 1.5
    	_Color("Reflection Color", Color)= (1.0,1.0,1.0,1)
    	_Normals("_Normals", 2D) = "black" {}
    	//_SpecGlossMap("Specular", 2D) = "white" {}
       	_Shininess ("Reflection Shininess", Range (0.03, 2)) = 1
   	 	_ReflectionColor("Reflection Color", Color)= (0.5,0.5,0.34,1)

    	_AtmosNear("_AtmosNear", Color) = (0.1686275,0.7372549,1,1)
    	_AtmosFar("_AtmosFar", Color) = (0.4557808,0.5187039,0.9850746,1)
    	_AtmosFalloff("_AtmosFalloff", Float) = 3

    	_NormalStrength ("Normal Strength", Range (0, 2)) = 0.6

      }

      SubShader 
      {
        Tags
        {
	    //"Queue"="Geometry"
	    //"IgnoreProjector"="False"
	    "IgnoreProjector"="True" 
	    "Queue"="Transparent" 
	    "RenderType"="Transparent"


        }


        //LOD 200  

    //Cull Back
    //ZWrite On
    //ZTest LEqual
    //ColorMask RGBA
    //Fog{
    //}


    CGPROGRAM

   	//#pragma vertex vert
	//#pragma fragment frag
	#pragma surface surf Lambert alpha
    #pragma target 3.0


    sampler2D _MainTex;
    half _Brightness; 
    sampler2D _Normals;
    //sampler2D _SpecGlossMap;
    half _Shininess;
  	float4 _ReflectionColor;
  	float4 _Color;
    
    float4 _AtmosNear;
    float4 _AtmosFar;
    float _AtmosFalloff;
    half _NormalStrength;


          struct EditorSurfaceOutput {
            half3 Albedo;
            half3 Normal;
            half3 Emission;
            half3 Gloss;
            half Specular;
            half Alpha;
            half4 Custom;
          };




   



          struct Input {
            float3 viewDir;
    float2 uv_MainTex;
    float2 uv_Normals;



          };
          void surf (Input IN, inout SurfaceOutput o) {
          //void surf (Input IN, inout EditorSurfaceOutput o) {
            o.Gloss = 0.0;
            o.Specular = 0;

            //o.Alpha = 1.0;

        float4 Fresnel0_1_NoInput = float4(0,0,1,1);
        float4 Fresnel0=(1.0 - dot( normalize( float4( IN.viewDir.x, IN.viewDir.y,IN.viewDir.z,1.0 ).xyz), normalize( Fresnel0_1_NoInput.xyz ) )).xxxx;
        float4 Pow0=pow(Fresnel0,_AtmosFalloff.xxxx);
        float4 Saturate0=saturate(Pow0);
        float4 Lerp0=lerp(_AtmosNear,_AtmosFar,Saturate0);
        float4 Multiply1=Lerp0 * Saturate0;
        float4 Sampled2D2=tex2D(_MainTex,IN.uv_MainTex.xy);
        float4 Add0=Multiply1 +  Sampled2D2;
        float4 Sampled2D0=tex2D(_Normals,IN.uv_Normals.xy);
        float4 UnpackNormal0=float4(UnpackNormal(Sampled2D0).xyz , 1.0);
        UnpackNormal0.xy = UnpackNormal0.xy * _NormalStrength;

        //fixed4 specTex = tex2D(_SpecGlossMap, IN.uv_MainTex.xy);


        o.Albedo = Add0 *_Brightness * _Color;

        o.Normal = UnpackNormal0;
        //o.Emission = 0.0;
        //o.Specular = tex2D(_SpecGlossMap, IN.uv_MainTex).rg;
        o.Alpha = Sampled2D2.a;
        o.Gloss = 0.2f;
        o.Specular = 0.5f;


            o.Normal = normalize(o.Normal);
          }
        ENDCG
      }
      Fallback "Diffuse"
}
