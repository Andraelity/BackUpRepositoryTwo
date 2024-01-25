﻿Shader "QuadraticBezier"
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


float3 trianglesGrid(float2 p )
{

    p *= 4.0;

    p.x += 0.5*p.y;
    
    float2 f = frac(p);
    float2 i = floor(p);
    
    float id = frac(frac(dot(i, float2(0.436,0.173))) * 45.0);
    if( f.x>f.y ) id += 1.3;
    
    float3  col = 0.5 + 0.5 * cos(0.7 * id  + float3(0.0,1.5,2.0 ) + 4.0);
    float pha = smoothstep(-1.0,1.0,sin(0.2*i.x + TIME + id*1.0));
    
    
    float2  pat = min(0.5-abs(f-0.5),abs(f.x-f.y)) - 0.3*pha;
    
    
    pat = smoothstep( 0.04, 0.07, pat );

    return col * pat.x * pat.y;

}



float3 sdBezier( in float2 pos, in float2 A, in float2 B, in float2 C )
{    
    float2 a = B - A;
    float2 b = A - 2.0*B + C;
    float2 c = a * 2.0;
    float2 d = A - pos;

    float kk = 1.0/dot(b,b);
    float kx = kk * dot(a,b);
    float ky = kk * (2.0*dot(a,a)+dot(d,b))/3.0;
    float kz = kk * dot(d,a);      

    float3 res;

    float p  = ky - kx*kx;
    float q  = kx*(2.0*kx*kx - 3.0*ky) + kz;
    float p3 = p*p*p;
    float q2 = q*q;
    float h  = q2 + 4.0*p3;

    if( h>=0.0 )  // 1 root
    {   
        h = sqrt(h);
        float2 x = (float2(h,-h)-q)/2.0;

        float2 uv = sign(x)*pow(abs(x), float2(1.0/3.0 , 1.0/3.0));
        float t = clamp( uv.x+uv.y-kx, 0.0, 1.0 );
        float2  q = d+(c+b*t)*t;
        res = float3(dot(q,q),q);
    }
    else          // 3 roots
    {   
        float z = sqrt(-p);
        float v = acos(q/(p*z*2.0))/3.0;
        float m = cos(v);
        float n = sin(v)*1.732050808;
        float3  t = clamp( float3(m+m,-n-m,n-m)*z-kx, 0.0, 1.0 );
        float2  qx = d+(c+b*t.x)*t.x; float dx=dot(qx,qx);
        float2  qy = d+(c+b*t.y)*t.y; float dy=dot(qy,qy);
        res = (dx<dy) ? float3(dx,qx) : float3(dy,qy);
    }
    
    res.x = sqrt(res.x);
    res.yz /= -res.x;
    
    return res;
}

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
                float3 backGround = trianglesGrid(p);
	
				// float4 col = float4(0.0,0.0,0.0, 1.0) - sign(d)*float4(col2, 1.0);
				// col *= 1.0 - exp(-48.0*abs(d));
				// col *= 0.8 + 0.2*cos(120.0*d);
				// col = lerp( col, float4(1.0, 1.0, 1.0, 1.0), 1.0-smoothstep(0.005,0.005,abs(d)) );

                p -= 0.3;
  
                // animate
                float2 v0 = float2(1.3,0.9)*cos(TIME * 0.5 + float2(0.0,5.0) );
                float2 v1 = float2(1.3,0.9)*cos(TIME * 0.6 + float2(3.0,4.0) );
                float2 v2 = float2(1.3,0.9)*cos(TIME * 0.7 + float2(2.0,0.0) );
                
                // sdf
                float3  dg = sdBezier( p, v0, v1, v2 );
                float d = dg.x;
                float2 g = dg.yz;
                    
                // central differenes based gradient, for comparison
                //g = vec2(dFdx(d),dFdy(d))/(2.0/iResolution.y);
                
                // float4 col = float4(0.0,0.0,0.0, 1.0) - sign(d)*float4(col2, 1.0);
                float4 col = (d>0.2) ? float4(0.0,0.0,0.0,0.0) : float4(backGround, 1.0); //vec3(0.4,0.7,0.85);

                col *= 1.0 - exp(-48.0*abs(d));
                // col *= 0.8 + 0.2*cos(120.0*d);
                col = lerp( col, float4(1.0, 1.0, 1.0, 1.0), 1.0-smoothstep(0.005,0.005,abs(d)) );
                
    // if(col.z == 0.0)
    // {
    // 	col = float4(col2, 1.0);
    // }

                    return float4(col);
					// return float4(col.xyz, (col.x + col.y + col.z )/3.0);


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

























