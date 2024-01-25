﻿Shader "MinusShape"
{
	Properties
	{
		_TextureChannel0 ("Texture", 2D) = "gray" {}
		_TextureChannel1 ("Texture", 2D) = "gray" {}
		_TextureChannel2 ("Texture", 2D) = "gray" {}
		_TextureChannel3 ("Texture", 2D) = "gray" {}


	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue" = "Transparent" "DisableBatching" ="true" }
		LOD 100

		Pass
		{
		    ZWrite Off
		    Cull off
		    Blend SrcAlpha OneMinusSrcAlpha
		    
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
                  #pragma multi_compile_instancing
			
			#include "UnityCG.cginc"

			struct vertexPoints
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
                  UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct pixel
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

            UNITY_INSTANCING_BUFFER_START(CommonProps)
            UNITY_DEFINE_INSTANCED_PROP(fixed4, _FillColor)
            UNITY_DEFINE_INSTANCED_PROP(float, _AASmoothing)
            UNITY_DEFINE_INSTANCED_PROP(float, _rangeZero_Ten)
            UNITY_DEFINE_INSTANCED_PROP(float, _rangeSOne_One)
            UNITY_DEFINE_INSTANCED_PROP(float, _rangeZoro_OneH)
            UNITY_DEFINE_INSTANCED_PROP(float, _mousePosition_x)
            UNITY_DEFINE_INSTANCED_PROP(float, _mousePosition_y)
            UNITY_INSTANCING_BUFFER_END(CommonProps)		

			pixel vert (vertexPoints v)
			{
				pixel o;
				
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.vertex.xy;
				return o;
			}
            
            sampler2D _TextureChannel0;
            sampler2D _TextureChannel1;
            sampler2D _TextureChannel2;
            sampler2D _TextureChannel3;
  			
            #define PI 3.1415926535897931
            #define TIME _Time.y
  
            float2 mouseCoordinateFunc(float x, float y)
            {
            	return normalize(float2(x,y));
            }

            /////////////////////////////////////////////////////////////////////////////////////////////
            // Default 
            /////////////////////////////////////////////////////////////////////////////////////////////


//-----------------

// #define opSubtract(p,A,B)\
//     /* regular subtraction */ \
//     max(A.x,-B.x);\
//     if( d>0.0 )\
//     {\
//         float2 op = p;\
//         for( int i=0; i<512; i++ ) \
//         { \
//             float d1=A.x; float2 g1=A.yz; \
//             float d2=B.x; float2 g2=B.yz; \
//             if( max(abs(d1),abs(d2))<0.001 ) break; \
//             p -= 0.5*(d1*g1 + d2*g2); \
//         } \
//         /* distance to closest intersection*/ \
//         float d3 = length(p-op);\
//         /* decide whether we should update distance */ \
//         float2  g1 = A.yz;\
//         float2  g2 = B.yz;\
//         float no = cro(g1,g2);\
//         if( cro(op-p,g1)*no>0.0 && cro(op-p,g2)*no>0.0) d = d3;\
//     }
    


// float3 sdgCircle( in float2 p, in float2 c, in float r ) 
// {
//     p -= c;
//     float l = length(p);
//     return float3( l-r, p/l );
// }

// // // SDFs from iquilezles.org/articles/distfunctions2d
// // // .x = f(p), .yz = ∇f(p) with ‖∇f(p)‖ = 1
// float3 sdgBox( in float2 p, in float2 b )
// {
//     float2 w = abs(p)-b;
//     float2 s = float2(p.x<0.0?-1:1,p.y<0.0?-1:1);
    
//     float g = max(w.x,w.y);
// 	float2  q = max(w,0.0);
//     float l = length(q);
    
//     return float3(   (g>0.0)?l: g,
//                 s*((g>0.0)?q/l : ((w.x>w.y)?float2(1,0):float2(0,1))));
// }


// float cro( float2 a, float2 b ) { return a.x*b.y - a.y*b.x; }



// float map( in float2 p )
// {
//     float2 off = 0.1*sin(TIME + float2(0.0,2.0));

//     float d = opSubtract( p, sdgBox(p, float2(0.3,0.6)), 
//                              sdgCircle(p, float2(0.0,0.2)+off,0.4) );
//     return d;
// }



    // float A = float3(T.x,0.0, 0.0);\
    // float B = float3(M.x,0.0, 0.0);\

#define opSubtract(A,B) max(A,-B);
    


float3 sdgCircle( in float2 p, in float2 c, in float r ) 
{
    p -= c;
    float l = length(p);
    return float3( l-r, p/l );
}

float3 sdgBox( in float2 p, in float2 b )
{
    float2 w = abs(p)-b;
    float2 s = float2(p.x<0.0?-1:1,p.y<0.0?-1:1);
    
    float g = max(w.x,w.y);
    float2  q = max(w,0.0);
    float l = length(q);
    
    return float3(   (g>0.0)?l: g,
                s*((g>0.0)?q/l : ((w.x>w.y)?float2(1,0):float2(0,1))));
}

float map( in float2 p )
{
    float2 off = 0.5 * sin(TIME);
    float A = sdgBox(p, float2(0.3,0.6)).x;
    float B = sdgCircle(p, float2(0.0,0.2)+ off, 0.4).x;

    float d = opSubtract(A,B);
                             
    return d;
}





// float2 gra( in float2 p )
// {
//     const float e = 0.0002;
//     return float2(map(p + float2(e,0.0))-map(p-vec2(e,0.0)),
//                 map(p + float2(0.0,e))-map(p-float2(0.0,e)))/(2.0*e);
// }






            fixed4 frag (pixel i) : SV_Target
			{
				
				//////////////////////////////////////////////////////////////////////////////////////////////
				///	DEFAULT
				//////////////////////////////////////////////////////////////////////////////////////////////

			    UNITY_SETUP_INSTANCE_ID(i);
			    
		    	float aaSmoothing = UNITY_ACCESS_INSTANCED_PROP(CommonProps, _AASmoothing);
			    fixed4 fillColor = UNITY_ACCESS_INSTANCED_PROP(CommonProps, _FillColor);
			   	float _rangeZero_Ten = UNITY_ACCESS_INSTANCED_PROP(CommonProps,_rangeZero_Ten);
				float _rangeSOne_One = UNITY_ACCESS_INSTANCED_PROP(CommonProps,_rangeSOne_One);
			    float _rangeZoro_OneH = UNITY_ACCESS_INSTANCED_PROP(CommonProps,_rangeZoro_OneH);
                float _mousePosition_x = UNITY_ACCESS_INSTANCED_PROP(CommonProps, _mousePosition_x);
                float _mousePosition_y = UNITY_ACCESS_INSTANCED_PROP(CommonProps, _mousePosition_y);

                float2 mouseCoordinate = mouseCoordinateFunc(_mousePosition_x, _mousePosition_y);
                float2 mouseCoordinateScale = (mouseCoordinate + 1.0)/ float2(2.0,2.0);

                
                float2 coordinate = i.uv;
                
                float2 coordinateBase = i.uv/(float2(2.0, 2.0));
                
                float2 coordinateScale = (coordinate + 1.0 )/ float2(2.0,2.0);
                
                float2 coordinateFull = ceil(coordinateBase);

                //Test Output 
                float3 colBase  = 0.0;
                float3 col2 = float3(coordinate.x + coordinate.y, coordinate.y - coordinate.x, pow(coordinate.x,2.0f));
				//////////////////////////////////////////////////////////////////////////////////////////////
				///	DEFAULT
				//////////////////////////////////////////////////////////////////////////////////////////////
	
                colBase = 0.0;
                //////////////////////////////////////////////////////////////////////////////////////////////
                
				// normalized pixel coordinates
    float2 p = coordinate;
    
    // distance
    float d = map(p);
    
    // coloring
    float4 col = (d>0.0) ? float4(col2.x,col2.y, col2.z,1.0) : float4(0.0, 0.0, 0.0, 0.0);
	// col *= 1.0 - exp2(-1.0*abs(d));
	// col *= 0.8 + 0.2*cos(128.0*abs(d));
	col = lerp( col, float4(0.0, 0.0, 0.0, 1.0), 1.0-smoothstep(0.002,0.005,abs(d)) );




				return float4(col);


				// return float4(vPixel/GetWindowResolution(), 0.0, 1.0);


				//(colBase.x + colBase.y + colBase.z)/3.0
                // return float4(coordinateScale, 0.0, 1.0);
				// return float4(right.x, up2.y, 0.0, 1.0);
				// return float4(coordinate3.x, coordinate3.y, 0.0, 1.0);
				// return float4(ro.xy, 0.0, 1.0);

				// float radio = 0.5;
				// float lenghtRadio = length(offset);

    //             if (lenghtRadio < radio)
    //             {
    //             	return float4(1, 0.0, 0.0, 1.0);
    //             }
    //             else
    //             {
    //             	return 0.0;
    //             }


				
			}

			ENDHLSL
		}
	}
}

























