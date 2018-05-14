// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.36 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.36;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-3612-OUT,spec-358-OUT,gloss-1796-OUT,normal-8032-OUT,difocc-4811-B,spcocc-4811-B;n:type:ShaderForge.SFN_Slider,id:358,x:32250,y:32780,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:4811,x:31250,y:32711,ptovrint:False,ptlb:MASK,ptin:_MASK,varname:node_4811,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e424cd0f2980f3d49a6b9dd6e99ab672,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7278,x:31658,y:32646,ptovrint:False,ptlb:ROCK_CLR,ptin:_ROCK_CLR,varname:node_7278,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ef13bdda7e74a0f4da25b80ca4e3de1f,ntxv:0,isnm:False|UVIN-3054-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:2256,x:31658,y:32821,ptovrint:False,ptlb:SAND_CLR,ptin:_SAND_CLR,varname:node_2256,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:63e596ed6052afd40897282552b96f55,ntxv:0,isnm:False|UVIN-3054-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:8709,x:31658,y:32458,ptovrint:False,ptlb:GRASS_CLR,ptin:_GRASS_CLR,varname:node_8709,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0a0d4fa4bebdaba479038fe27a62c229,ntxv:0,isnm:False|UVIN-3054-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:3374,x:31677,y:33181,ptovrint:False,ptlb:GRASS_NMT,ptin:_GRASS_NMT,varname:node_3374,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8a263c67c7e8e7a4eb7544fbdb669264,ntxv:0,isnm:False|UVIN-3054-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:860,x:31677,y:33558,ptovrint:False,ptlb:SAND_NMT,ptin:_SAND_NMT,varname:node_860,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:672fea5d7b3dfb64d948997494c26967,ntxv:0,isnm:False|UVIN-3054-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:722,x:31677,y:33369,ptovrint:False,ptlb:ROCK_NMT,ptin:_ROCK_NMT,varname:node_722,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d3550339fc3a99a4db0d3b1318d1ed71,ntxv:0,isnm:False|UVIN-3054-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:5040,x:31515,y:32646,ptovrint:False,ptlb:ROCK_GRADIENT,ptin:_ROCK_GRADIENT,varname:node_5040,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a832594ccc7e0734f9a1cc8d89bd1c28,ntxv:0,isnm:False|UVIN-353-OUT;n:type:ShaderForge.SFN_Tex2d,id:9247,x:31515,y:32458,ptovrint:False,ptlb:GRASS_GRADIENT,ptin:_GRASS_GRADIENT,varname:node_9247,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0244eda2c35f8f7449ffc78a9c380059,ntxv:0,isnm:False|UVIN-353-OUT;n:type:ShaderForge.SFN_Tex2d,id:9239,x:31515,y:32821,ptovrint:False,ptlb:SAND_GRADIENT,ptin:_SAND_GRADIENT,varname:node_9239,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:395f78ae1a0edec42bd7ed372a77cd46,ntxv:0,isnm:False|UVIN-353-OUT;n:type:ShaderForge.SFN_Multiply,id:1758,x:31850,y:32646,varname:node_1758,prsc:2|A-7278-RGB,B-5040-RGB;n:type:ShaderForge.SFN_Multiply,id:5306,x:31850,y:32821,varname:node_5306,prsc:2|A-2256-RGB,B-9239-RGB;n:type:ShaderForge.SFN_Multiply,id:4817,x:31850,y:32475,varname:node_4817,prsc:2|A-8709-RGB,B-9247-RGB;n:type:ShaderForge.SFN_Multiply,id:353,x:31352,y:32504,varname:node_353,prsc:2|A-1528-OUT,B-8665-OUT;n:type:ShaderForge.SFN_Vector2,id:8665,x:31141,y:32479,varname:node_8665,prsc:2,v1:1,v2:1;n:type:ShaderForge.SFN_UVTile,id:3054,x:31515,y:33007,varname:node_3054,prsc:2|WDT-703-OUT,HGT-4604-OUT,TILE-492-OUT;n:type:ShaderForge.SFN_Vector1,id:703,x:31363,y:33024,varname:node_703,prsc:2,v1:0.05;n:type:ShaderForge.SFN_Vector1,id:4604,x:31363,y:33073,varname:node_4604,prsc:2,v1:0.05;n:type:ShaderForge.SFN_Vector1,id:492,x:31363,y:33131,varname:node_492,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:1783,x:32082,y:32541,varname:node_1783,prsc:2|A-5306-OUT,B-4817-OUT,T-4811-G;n:type:ShaderForge.SFN_Lerp,id:5584,x:32250,y:32592,varname:node_5584,prsc:2|A-1783-OUT,B-1758-OUT,T-4811-R;n:type:ShaderForge.SFN_Multiply,id:3612,x:32460,y:32566,varname:node_3612,prsc:2|A-5584-OUT,B-4811-B;n:type:ShaderForge.SFN_Lerp,id:5530,x:31910,y:33181,varname:node_5530,prsc:2|A-860-RGB,B-3374-RGB,T-4811-G;n:type:ShaderForge.SFN_Lerp,id:1191,x:32104,y:33385,varname:node_1191,prsc:2|A-5530-OUT,B-722-RGB,T-4811-R;n:type:ShaderForge.SFN_Lerp,id:2212,x:31708,y:33783,varname:node_2212,prsc:2|A-7829-OUT,B-6560-OUT,T-4811-G;n:type:ShaderForge.SFN_Lerp,id:2717,x:31895,y:33895,varname:node_2717,prsc:2|A-2212-OUT,B-2063-OUT,T-4811-R;n:type:ShaderForge.SFN_Vector1,id:6560,x:31358,y:33718,varname:node_6560,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Vector1,id:2063,x:31358,y:33802,varname:node_2063,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:7829,x:31358,y:33891,varname:node_7829,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Multiply,id:4556,x:32301,y:33679,varname:node_4556,prsc:2|A-1528-OUT,B-2717-OUT;n:type:ShaderForge.SFN_Multiply,id:1796,x:32465,y:33463,varname:node_1796,prsc:2|A-4811-A,B-4556-OUT;n:type:ShaderForge.SFN_Vector1,id:9831,x:30939,y:32947,varname:node_9831,prsc:2,v1:0.005;n:type:ShaderForge.SFN_Vector1,id:3548,x:31003,y:33011,varname:node_3548,prsc:2,v1:0.995;n:type:ShaderForge.SFN_Normalize,id:8032,x:32236,y:33099,varname:node_8032,prsc:2|IN-1191-OUT;n:type:ShaderForge.SFN_Clamp,id:1528,x:31186,y:32913,varname:node_1528,prsc:2|IN-4811-A,MIN-9831-OUT,MAX-3548-OUT;proporder:358-4811-8709-9247-7278-2256-5040-9239-3374-860-722;pass:END;sub:END;*/

Shader "Shader Forge/Island_Terrain" {
    Properties {
        _Metallic ("Metallic", Range(0, 1)) = 0
        _MASK ("MASK", 2D) = "white" {}
        _GRASS_CLR ("GRASS_CLR", 2D) = "white" {}
        _GRASS_GRADIENT ("GRASS_GRADIENT", 2D) = "white" {}
        _ROCK_CLR ("ROCK_CLR", 2D) = "white" {}
        _SAND_CLR ("SAND_CLR", 2D) = "white" {}
        _ROCK_GRADIENT ("ROCK_GRADIENT", 2D) = "white" {}
        _SAND_GRADIENT ("SAND_GRADIENT", 2D) = "white" {}
        _GRASS_NMT ("GRASS_NMT", 2D) = "white" {}
        _SAND_NMT ("SAND_NMT", 2D) = "white" {}
        _ROCK_NMT ("ROCK_NMT", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float _Metallic;
            uniform sampler2D _MASK; uniform float4 _MASK_ST;
            uniform sampler2D _ROCK_CLR; uniform float4 _ROCK_CLR_ST;
            uniform sampler2D _SAND_CLR; uniform float4 _SAND_CLR_ST;
            uniform sampler2D _GRASS_CLR; uniform float4 _GRASS_CLR_ST;
            uniform sampler2D _GRASS_NMT; uniform float4 _GRASS_NMT_ST;
            uniform sampler2D _SAND_NMT; uniform float4 _SAND_NMT_ST;
            uniform sampler2D _ROCK_NMT; uniform float4 _ROCK_NMT_ST;
            uniform sampler2D _ROCK_GRADIENT; uniform float4 _ROCK_GRADIENT_ST;
            uniform sampler2D _GRASS_GRADIENT; uniform float4 _GRASS_GRADIENT_ST;
            uniform sampler2D _SAND_GRADIENT; uniform float4 _SAND_GRADIENT_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float node_703 = 0.05;
                float node_492 = 1.0;
                float2 node_3054_tc_rcp = float2(1.0,1.0)/float2( node_703, 0.05 );
                float node_3054_ty = floor(node_492 * node_3054_tc_rcp.x);
                float node_3054_tx = node_492 - node_703 * node_3054_ty;
                float2 node_3054 = (i.uv0 + float2(node_3054_tx, node_3054_ty)) * node_3054_tc_rcp;
                float4 _SAND_NMT_var = tex2D(_SAND_NMT,TRANSFORM_TEX(node_3054, _SAND_NMT));
                float4 _GRASS_NMT_var = tex2D(_GRASS_NMT,TRANSFORM_TEX(node_3054, _GRASS_NMT));
                float4 _MASK_var = tex2D(_MASK,TRANSFORM_TEX(i.uv0, _MASK));
                float4 _ROCK_NMT_var = tex2D(_ROCK_NMT,TRANSFORM_TEX(node_3054, _ROCK_NMT));
                float3 normalLocal = normalize(lerp(lerp(_SAND_NMT_var.rgb,_GRASS_NMT_var.rgb,_MASK_var.g),_ROCK_NMT_var.rgb,_MASK_var.r));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float node_9831 = 0.005;
                float node_3548 = 0.995;
                float node_1528 = clamp(_MASK_var.a,node_9831,node_3548);
                float gloss = (_MASK_var.a*(node_1528*lerp(lerp(0.3,0.2,_MASK_var.g),0.5,_MASK_var.r)));
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularAO = _MASK_var.b;
                float3 specularColor = float3(_Metallic,_Metallic,_Metallic);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 indirectSpecular = (gi.indirect.specular) * specularAO*specularColor;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                indirectDiffuse *= _MASK_var.b; // Diffuse AO
                float4 _SAND_CLR_var = tex2D(_SAND_CLR,TRANSFORM_TEX(node_3054, _SAND_CLR));
                float2 node_353 = (node_1528*float2(1,1));
                float4 _SAND_GRADIENT_var = tex2D(_SAND_GRADIENT,TRANSFORM_TEX(node_353, _SAND_GRADIENT));
                float4 _GRASS_CLR_var = tex2D(_GRASS_CLR,TRANSFORM_TEX(node_3054, _GRASS_CLR));
                float4 _GRASS_GRADIENT_var = tex2D(_GRASS_GRADIENT,TRANSFORM_TEX(node_353, _GRASS_GRADIENT));
                float4 _ROCK_CLR_var = tex2D(_ROCK_CLR,TRANSFORM_TEX(node_3054, _ROCK_CLR));
                float4 _ROCK_GRADIENT_var = tex2D(_ROCK_GRADIENT,TRANSFORM_TEX(node_353, _ROCK_GRADIENT));
                float3 diffuseColor = (lerp(lerp((_SAND_CLR_var.rgb*_SAND_GRADIENT_var.rgb),(_GRASS_CLR_var.rgb*_GRASS_GRADIENT_var.rgb),_MASK_var.g),(_ROCK_CLR_var.rgb*_ROCK_GRADIENT_var.rgb),_MASK_var.r)*_MASK_var.b);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float _Metallic;
            uniform sampler2D _MASK; uniform float4 _MASK_ST;
            uniform sampler2D _ROCK_CLR; uniform float4 _ROCK_CLR_ST;
            uniform sampler2D _SAND_CLR; uniform float4 _SAND_CLR_ST;
            uniform sampler2D _GRASS_CLR; uniform float4 _GRASS_CLR_ST;
            uniform sampler2D _GRASS_NMT; uniform float4 _GRASS_NMT_ST;
            uniform sampler2D _SAND_NMT; uniform float4 _SAND_NMT_ST;
            uniform sampler2D _ROCK_NMT; uniform float4 _ROCK_NMT_ST;
            uniform sampler2D _ROCK_GRADIENT; uniform float4 _ROCK_GRADIENT_ST;
            uniform sampler2D _GRASS_GRADIENT; uniform float4 _GRASS_GRADIENT_ST;
            uniform sampler2D _SAND_GRADIENT; uniform float4 _SAND_GRADIENT_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float node_703 = 0.05;
                float node_492 = 1.0;
                float2 node_3054_tc_rcp = float2(1.0,1.0)/float2( node_703, 0.05 );
                float node_3054_ty = floor(node_492 * node_3054_tc_rcp.x);
                float node_3054_tx = node_492 - node_703 * node_3054_ty;
                float2 node_3054 = (i.uv0 + float2(node_3054_tx, node_3054_ty)) * node_3054_tc_rcp;
                float4 _SAND_NMT_var = tex2D(_SAND_NMT,TRANSFORM_TEX(node_3054, _SAND_NMT));
                float4 _GRASS_NMT_var = tex2D(_GRASS_NMT,TRANSFORM_TEX(node_3054, _GRASS_NMT));
                float4 _MASK_var = tex2D(_MASK,TRANSFORM_TEX(i.uv0, _MASK));
                float4 _ROCK_NMT_var = tex2D(_ROCK_NMT,TRANSFORM_TEX(node_3054, _ROCK_NMT));
                float3 normalLocal = normalize(lerp(lerp(_SAND_NMT_var.rgb,_GRASS_NMT_var.rgb,_MASK_var.g),_ROCK_NMT_var.rgb,_MASK_var.r));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float node_9831 = 0.005;
                float node_3548 = 0.995;
                float node_1528 = clamp(_MASK_var.a,node_9831,node_3548);
                float gloss = (_MASK_var.a*(node_1528*lerp(lerp(0.3,0.2,_MASK_var.g),0.5,_MASK_var.r)));
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(_Metallic,_Metallic,_Metallic);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _SAND_CLR_var = tex2D(_SAND_CLR,TRANSFORM_TEX(node_3054, _SAND_CLR));
                float2 node_353 = (node_1528*float2(1,1));
                float4 _SAND_GRADIENT_var = tex2D(_SAND_GRADIENT,TRANSFORM_TEX(node_353, _SAND_GRADIENT));
                float4 _GRASS_CLR_var = tex2D(_GRASS_CLR,TRANSFORM_TEX(node_3054, _GRASS_CLR));
                float4 _GRASS_GRADIENT_var = tex2D(_GRASS_GRADIENT,TRANSFORM_TEX(node_353, _GRASS_GRADIENT));
                float4 _ROCK_CLR_var = tex2D(_ROCK_CLR,TRANSFORM_TEX(node_3054, _ROCK_CLR));
                float4 _ROCK_GRADIENT_var = tex2D(_ROCK_GRADIENT,TRANSFORM_TEX(node_353, _ROCK_GRADIENT));
                float3 diffuseColor = (lerp(lerp((_SAND_CLR_var.rgb*_SAND_GRADIENT_var.rgb),(_GRASS_CLR_var.rgb*_GRASS_GRADIENT_var.rgb),_MASK_var.g),(_ROCK_CLR_var.rgb*_ROCK_GRADIENT_var.rgb),_MASK_var.r)*_MASK_var.b);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float _Metallic;
            uniform sampler2D _MASK; uniform float4 _MASK_ST;
            uniform sampler2D _ROCK_CLR; uniform float4 _ROCK_CLR_ST;
            uniform sampler2D _SAND_CLR; uniform float4 _SAND_CLR_ST;
            uniform sampler2D _GRASS_CLR; uniform float4 _GRASS_CLR_ST;
            uniform sampler2D _ROCK_GRADIENT; uniform float4 _ROCK_GRADIENT_ST;
            uniform sampler2D _GRASS_GRADIENT; uniform float4 _GRASS_GRADIENT_ST;
            uniform sampler2D _SAND_GRADIENT; uniform float4 _SAND_GRADIENT_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float node_703 = 0.05;
                float node_492 = 1.0;
                float2 node_3054_tc_rcp = float2(1.0,1.0)/float2( node_703, 0.05 );
                float node_3054_ty = floor(node_492 * node_3054_tc_rcp.x);
                float node_3054_tx = node_492 - node_703 * node_3054_ty;
                float2 node_3054 = (i.uv0 + float2(node_3054_tx, node_3054_ty)) * node_3054_tc_rcp;
                float4 _SAND_CLR_var = tex2D(_SAND_CLR,TRANSFORM_TEX(node_3054, _SAND_CLR));
                float4 _MASK_var = tex2D(_MASK,TRANSFORM_TEX(i.uv0, _MASK));
                float node_9831 = 0.005;
                float node_3548 = 0.995;
                float node_1528 = clamp(_MASK_var.a,node_9831,node_3548);
                float2 node_353 = (node_1528*float2(1,1));
                float4 _SAND_GRADIENT_var = tex2D(_SAND_GRADIENT,TRANSFORM_TEX(node_353, _SAND_GRADIENT));
                float4 _GRASS_CLR_var = tex2D(_GRASS_CLR,TRANSFORM_TEX(node_3054, _GRASS_CLR));
                float4 _GRASS_GRADIENT_var = tex2D(_GRASS_GRADIENT,TRANSFORM_TEX(node_353, _GRASS_GRADIENT));
                float4 _ROCK_CLR_var = tex2D(_ROCK_CLR,TRANSFORM_TEX(node_3054, _ROCK_CLR));
                float4 _ROCK_GRADIENT_var = tex2D(_ROCK_GRADIENT,TRANSFORM_TEX(node_353, _ROCK_GRADIENT));
                float3 diffColor = (lerp(lerp((_SAND_CLR_var.rgb*_SAND_GRADIENT_var.rgb),(_GRASS_CLR_var.rgb*_GRASS_GRADIENT_var.rgb),_MASK_var.g),(_ROCK_CLR_var.rgb*_ROCK_GRADIENT_var.rgb),_MASK_var.r)*_MASK_var.b);
                float3 specColor = float3(_Metallic,_Metallic,_Metallic);
                float roughness = 1.0 - (_MASK_var.a*(node_1528*lerp(lerp(0.3,0.2,_MASK_var.g),0.5,_MASK_var.r)));
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
