Shader "ShaderBloom/ContainerShader-SphereMeta"
{

	Properties {
		[HideInInspector]_Color ("Tint", Color) = (0, 0, 0, 0)
		[HDR]_ColorGlowHDR ("ColorValue", Color) = (1, 1, 1, 1)
		_AlphaColor ("AlphaColor", Range(-3, 3)) = 0.5
		[HideInInspector]_MainTex ("Albedo", 2D) = "white" {}

		[HideInInspector][NoScaleOffset] _NormalMap ("Normals", 2D) = "bump" {}
		[HideInInspector]_BumpScale ("Bump Scale", Float) = 1

		[HideInInspector][NoScaleOffset] _MetallicMap ("Metallic", 2D) = "white" {}
		[HideInInspector][Gamma] _Metallic ("Metallic", Range(0, 1)) = 0
		[HideInInspector]_Smoothness ("Smoothness", Range(0, 1)) = 0.1

		[HideInInspector][NoScaleOffset] _ParallaxMap ("Parallax", 2D) = "black" {}
		[HideInInspector]_ParallaxStrength ("Parallax Strength", Range(0, 0.1)) = 0

		[HideInInspector][NoScaleOffset] _OcclusionMap ("Occlusion", 2D) = "white" {}
		[HideInInspector]_OcclusionStrength ("Occlusion Strength", Range(0, 1)) = 1

		[HideInInspector][NoScaleOffset] _EmissionMap ("Emission", 2D) = "black" {}
		[HideInInspector][HDR]_Emission ("Emission", Color) = (0, 0, 0)

		[HideInInspector][NoScaleOffset] _DetailMask ("Detail Mask", 2D) = "white" {}
		[HideInInspector]_DetailTex ("Detail Albedo", 2D) = "gray" {}
		[HideInInspector][NoScaleOffset] _DetailNormalMap ("Detail Normals", 2D) = "bump" {}
		[HideInInspector]_DetailBumpScale ("Detail Bump Scale", Float) = 1

		[HideInInspector]_Cutoff ("Alpha Cutoff", Range(0, 1)) = 0.0

		[HideInInspector] _SrcBlend ("_SrcBlend", Float) = 1
		[HideInInspector] _DstBlend ("_DstBlend", Float) = 1
		[HideInInspector] _ZWrite ("_ZWrite", Float) = 0



	    //_ColorOperation ("ColorForSomething", Color) = (1.0, 1.0, 1.0, 1.0)

        _TextureSprite ("_TextureSprite", 2D)     = "green" {}
        _TextureChannel0 ("_TextureChannel0", 2D) = "green" {}
        _TextureChannel1 ("_TextureChannel1", 2D) = "green" {}
        _TextureChannel2 ("_TextureChannel2", 2D) = "green" {}
        _TextureChannel3 ("_TextureChannel3", 2D) = "green" {}


        _OverlaySelection("_OverlaySelection", Range(0.0, 1.0)) = 1.0

        _StickerType("_StickerType", Float) = 1.0
        _MotionState("_MotionState", Float) = 1.0
        _BorderColor("_BorderColor", Color) = (1.0, 1.0, 1.0, 1.0)
        _BorderSizeOne("_BorderSizeOne", Float) = 1.0
        _BorderSizeTwo("_BorderSizeTwo", Float) = 1.0
        _BorderBlurriness("_BorderBlurriness", Float) = 1.0
        _RangeSOne_One0("_RangeSOne_One0", Float) = 1.0
        _RangeSOne_One1("_RangeSOne_One1", Float) = 1.0
        _RangeSOne_One2("_RangeSOne_One2", Float) = 1.0
        _RangeSOne_One3("_RangeSOne_One3", Float) = 1.0
        _RangeSTen_Ten0("_RangeSTen_Ten0", Float) = 1.0
        _RangeSTen_Ten1("_RangeSTen_Ten1", Float) = 1.0
        _RangeSTen_Ten2("_RangeSTen_Ten2", Float) = 1.0
        _RangeSTen_Ten3("_RangeSTen_Ten3", Float) = 1.0

        _InVariableTickY(" _InVariableTickY", Float) = 1.0
        _InVariableRatioX("_InVariableRatioX", Float) = 1.0
        _InVariableRatioY("_InVariableRatioY", Float) = 1.0
        _OutlineColor("_OutlineColor", Color) = (1.0, 1.0, 1.0, 1.0)
        _OutlineSprite("_OutlineSprite", Float) = 1.0

        _GlowFull("_GlowFull", Range(0.0, 1.0)) = 0.0


	}

	HLSLINCLUDE

	#define BINORMAL_PER_FRAGMENT
	#define FOG_DISTANCE

	#define PARALLAX_BIAS 0
//	#define PARALLAX_OFFSET_LIMITING
	#define PARALLAX_RAYMARCHING_STEPS 10
	#define PARALLAX_RAYMARCHING_INTERPOLATE
//	#define PARALLAX_RAYMARCHING_SEARCH_STEPS 3
	#define PARALLAX_FUNCTION ParallaxRaymarching
	#define PARALLAX_SUPPORT_SCALED_DYNAMIC_BATCHING

	ENDHLSL

	SubShader 
	{

        LOD 500


		Pass 
		{
			Tags 
			{
				"LightMode" = "ForwardBase"
				"RenderType"="Transparent" "Queue" = "Transparent" "DisableBatching" ="true" 

			}
			// Blend [_SrcBlend] [_DstBlend]
			ZWrite [_ZWrite]
            Cull off
            Blend SrcAlpha OneMinusSrcAlpha
			HLSLPROGRAM

			#pragma target 3.0

			#pragma shader_feature _ _RENDERING_CUTOUT _RENDERING_FADE _RENDERING_TRANSPARENT
			#pragma shader_feature _METALLIC_MAP
			#pragma shader_feature _ _SMOOTHNESS_ALBEDO _SMOOTHNESS_METALLIC
			#pragma shader_feature _NORMAL_MAP
			#pragma shader_feature _PARALLAX_MAP
			#pragma shader_feature _OCCLUSION_MAP
			#pragma shader_feature _EMISSION_MAP
			#pragma shader_feature _DETAIL_MASK
			#pragma shader_feature _DETAIL_ALBEDO_MAP
			#pragma shader_feature _DETAIL_NORMAL_MAP

			#pragma multi_compile _ LOD_FADE_CROSSFADE

			#pragma multi_compile_fwdbase
			#pragma multi_compile_fog
			#pragma multi_compile_instancing
			#pragma instancing_options lodfade force_same_maxcount_for_gl

			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram

			#define FORWARD_BASE_PASS

			#include "Lighting/My Lighting.cginc"

			ENDHLSL
		}



		Pass 
		{
			Tags 
			{
				"LightMode" = "ForwardAdd"
				"RenderType"="Transparent" "Queue" = "Transparent" "DisableBatching" ="true" 
			}

			// Blend [_SrcBlend] One
			ZWrite Off
            Cull off
            Blend SrcAlpha OneMinusSrcAlpha
			
			HLSLPROGRAM

			#pragma target 3.0

			#pragma shader_feature _ _RENDERING_CUTOUT _RENDERING_FADE _RENDERING_TRANSPARENT
			#pragma shader_feature _METALLIC_MAP
			#pragma shader_feature _ _SMOOTHNESS_ALBEDO _SMOOTHNESS_METALLIC
			#pragma shader_feature _NORMAL_MAP
			#pragma shader_feature _PARALLAX_MAP
			#pragma shader_feature _DETAIL_MASK
			#pragma shader_feature _DETAIL_ALBEDO_MAP
			#pragma shader_feature _DETAIL_NORMAL_MAP

			#pragma multi_compile _ LOD_FADE_CROSSFADE

			#pragma multi_compile_fwdadd_fullshadows
			#pragma multi_compile_fog
			
			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram

			#include "Lighting/My Lighting.cginc"

			ENDHLSL
		}




		Pass 
		{
			Tags 
			{
				"LightMode" = "Deferred"
				"RenderType"="Transparent" "Queue" = "Transparent" "DisableBatching" ="true" 
			}

       		ZWrite Off
            Cull off
            Blend SrcAlpha OneMinusSrcAlpha
			HLSLPROGRAM

			#pragma target 3.0
			#pragma exclude_renderers nomrt

			#pragma shader_feature _ _RENDERING_CUTOUT
			#pragma shader_feature _METALLIC_MAP
			#pragma shader_feature _ _SMOOTHNESS_ALBEDO _SMOOTHNESS_METALLIC
			#pragma shader_feature _NORMAL_MAP
			#pragma shader_feature _PARALLAX_MAP
			#pragma shader_feature _OCCLUSION_MAP
			#pragma shader_feature _EMISSION_MAP
			#pragma shader_feature _DETAIL_MASK
			#pragma shader_feature _DETAIL_ALBEDO_MAP
			#pragma shader_feature _DETAIL_NORMAL_MAP

			#pragma multi_compile _ LOD_FADE_CROSSFADE

			#pragma multi_compile_prepassfinal
			#pragma multi_compile_instancing
			#pragma instancing_options lodfade

			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram

			#define DEFERRED_PASS

			#include "Lighting/My Lighting.cginc"

			ENDHLSL
		}




		Pass 
		{
			Tags 
			{
				"LightMode" = "Meta"
				"RenderType"="Transparent" 
				"Queue" = "Transparent" 
				"DisableBatching" ="true" }


            ZWrite Off
            Cull off
            Blend SrcAlpha OneMinusSrcAlpha
			

			Cull Off

			HLSLPROGRAM

			#pragma vertex MyLightmappingVertexProgram
			#pragma fragment MyLightmappingFragmentProgram

			#pragma shader_feature _METALLIC_MAP
			#pragma shader_feature _ _SMOOTHNESS_ALBEDO _SMOOTHNESS_METALLIC
			#pragma shader_feature _EMISSION_MAP
			#pragma shader_feature _DETAIL_MASK
			#pragma shader_feature _DETAIL_ALBEDO_MAP

			#include "Lighting/My Lightmapping.cginc"

			ENDHLSL
		}


		
		Pass 
		{
			Tags 
			{
				"LightMode" = "ForwardBase"
				"RenderType"="Transparent" "Queue" = "Transparent" "DisableBatching" ="true" 

			}
			// Blend [_SrcBlend] [_DstBlend]
			ZWrite [_ZWrite]
            Cull off
            Blend SrcAlpha OneMinusSrcAlpha
			HLSLPROGRAM

			#pragma target 3.0

			#pragma shader_feature _ _RENDERING_CUTOUT _RENDERING_FADE _RENDERING_TRANSPARENT
			#pragma shader_feature _METALLIC_MAP
			#pragma shader_feature _ _SMOOTHNESS_ALBEDO _SMOOTHNESS_METALLIC
			#pragma shader_feature _NORMAL_MAP
			#pragma shader_feature _PARALLAX_MAP
			#pragma shader_feature _OCCLUSION_MAP
			#pragma shader_feature _EMISSION_MAP
			#pragma shader_feature _DETAIL_MASK
			#pragma shader_feature _DETAIL_ALBEDO_MAP
			#pragma shader_feature _DETAIL_NORMAL_MAP

			#pragma multi_compile _ LOD_FADE_CROSSFADE

			#pragma multi_compile_fwdbase
			#pragma multi_compile_fog
			#pragma multi_compile_instancing
			#pragma instancing_options lodfade force_same_maxcount_for_gl

			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram

			#define FORWARD_BASE_PASS
			float4 _ColorGlowHDR;
			#include "Lighting/MY Lighting.cginc"

			ENDHLSL
		}

        Pass
        {
			Tags { "RenderType"="Transparent" "Queue" = "Transparent" "DisableBatching" ="true" }
            
            ZWrite Off
            Cull off
            Blend SrcAlpha OneMinusSrcAlpha
            
            HLSLPROGRAM
            #pragma vertex VERTEXSHADER
            #pragma fragment FRAGMENTSHADER
            
            #pragma multi_compile_instancing
            

            #include "UnityCG.cginc"
            #include "FolderIncludes/Shader-SphereMeta.HLSL"


			ENDHLSL
		}


		 // Pass
        // {
			// Tags { "RenderType"="Transparent" "Queue" = "Transparent" "DisableBatching" ="true" }
            // 
            // ZWrite Off
            // Cull off
            // Blend SrcAlpha OneMinusSrcAlpha
            
            // HLSLPROGRAM

            // #pragma vertex VERTEXSHADER
            // #pragma fragment FRAGMENTSHADER
            // 
            // #pragma multi_compile_instancing
            

            // #include "UnityCG.cginc"
            // #include "FolderIncludes/TEMPLATESHADER.HLSL"

			// ENDHLSL
		// }


	}

	CustomEditor "CustomMaterialSticker_ShaderGUI"
}