using System.Collections;
using System.Collections.Generic;
using static Unity.Mathematics.math;
using UnityEngine;
using Unity.Mathematics;

public class CalcWavePos : MonoBehaviour
{

    
    public Material mat;
    Rigidbody rb;
    
    private void Start()
    {
        //pos = transform.position;
        rb = GetComponent<Rigidbody>();

    }
    private void FixedUpdate()
    {
        
        RaycastHit hit;
        Ray downRay = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position,Vector3.down,Color.red);
        if (Physics.Raycast(downRay, out hit))
        {

            mat = hit.transform.GetComponent<Renderer>().material;
            //Debug.Log(hit.transform.name);
        }


        Vector3 pos;
        pos = transform.position;
        Vector2 XZpos = new Vector2(pos.x, pos.z);
        XZpos = XZpos * mat.GetVector("Vector2_58974A61");
        XZpos = XZpos * mat.GetFloat("Vector1_C141BEFF");
        float time = Time.deltaTime;
        mat.SetFloat("Vector1_ABC566D8", time);
        Vector2 offset = ((time * mat.GetVector("Vector2_F75269F6")) / mat.GetFloat("Vector1_B16EAA93"))*mat.GetFloat("Vector1_1D80FE4E");
        Vector2 tileOffset = (XZpos * mat.GetVector("Vector2_F6EACA16")) + offset;

        float noise = GetNoiseValue(tileOffset, mat.GetFloat("Vector1_AA620FA8"));
        
        float Ypos = noise * mat.GetFloat("Vector1_DDE034AE");
        //Debug.Log(mat.GetVector("Vector2_58974A61"));
        //float YposG = transform.TransformPoint(0f, Ypos, 0f).y;
        transform.position = new Vector3(transform.position.x, Ypos, transform.position.z);
    }


    private float GetNoiseValue(Vector2 UV,float scale)
    {
        
        Unity_SimpleNoise_float(UV, scale,out float o);
        return o;
    }

    float unity_noise_randomValue(float2 uv)
    {
        return frac(sin(dot(uv, float2(12f, 78f))) * 43758f); 
    }

    float unity_noise_interpolate(float a, float b, float t)
    {
        return (1.0f - t) * a + (t * b);
    }

    float unity_valueNoise(float2 uv)
    {
        float2 i = floor(uv);
        float2 f = frac(uv);
        f = f * f * (3.0f - 2.0f * f);

        uv = abs(frac(uv) - 0.5f);
        float2 c0 = i + float2(0.0f, 0.0f);
        float2 c1 = i + float2(1.0f, 0.0f);
        float2 c2 = i + float2(0.0f, 1.0f);
        float2 c3 = i + float2(1.0f, 1.0f);
        float r0 = unity_noise_randomValue(c0);
        float r1 = unity_noise_randomValue(c1);
        float r2 = unity_noise_randomValue(c2);
        float r3 = unity_noise_randomValue(c3);

        float bottomOfGrid = unity_noise_interpolate(r0, r1, f.x);
        float topOfGrid = unity_noise_interpolate(r2, r3, f.x);
        float t = unity_noise_interpolate(bottomOfGrid, topOfGrid, f.y);
        return t;
    }

    void Unity_SimpleNoise_float(float2 UV, float Scale, out float Out)
    {
        float t = 0.0f;

        float freq = pow(2.0f, 0f);
        float amp = pow(0.5f, (3f - 0f));
        t += unity_valueNoise(float2(UV.x * Scale / freq, UV.y * Scale / freq)) * amp;

        freq = pow(2.0f, 1f);
        amp = pow(0.5f, (3f - 1f));
        t += unity_valueNoise(float2(UV.x * Scale / freq, UV.y * Scale / freq)) * amp;

        freq = pow(2.0f, 2f);
        amp = pow(0.5f, (3f - 2f));
        t += unity_valueNoise(float2(UV.x * Scale / freq, UV.y * Scale / freq)) * amp;

        Out = t;
    }


}
