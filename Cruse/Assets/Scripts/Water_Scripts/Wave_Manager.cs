using System.Collections;
using System.Collections.Generic;
using static Unity.Mathematics.math;
using Unity.Mathematics;
using UnityEngine;

public class Wave_Manager : MonoBehaviour
{
    public static Wave_Manager WMInstance;

    public float amp = 1f;
    public float len = 2f;
    public float vel = 1f;
    public Vector2 off;
    private Material mat;
    // Start is called before the first frame update
    private void Awake()
    {
        if(WMInstance == null)
        {
            WMInstance = this;
        }
        else if (WMInstance != this)
        {
            Debug.Log("Water Manager Instance already exists, destroing object!");
            Destroy(this);
        }
        mat = gameObject.transform.GetComponent<Renderer>().material;
    }

    
    public float GetWaveYCord(float x,float z)
    {

        Vector2 pos = new Vector2(x, z);
        Vector2 UV = (pos * mat.GetVector("Vector2_58974A61"))* mat.GetFloat("Vector1_C141BEFF");

        Vector2 Tile = mat.GetVector("Vector2_F6EACA16");

        Vector2 Offset = ((Time.time * mat.GetVector("Vector2_F75269F6")) / mat.GetFloat("Vector1_B16EAA93")) * mat.GetFloat("Vector1_1D80FE4E");

        Vector2 TilingAndOffset = UV * Tile + Offset;

        float noise = GetNoiseValue(TilingAndOffset,mat.GetFloat("Vector1_AA620FA8"));
        //do noise calc

        float tmp = (noise * mat.GetFloat("Vector1_DDE034AE"));
        return  tmp ;
    }
    float GetNoiseValue(Vector2 tiling,float scale)
    {
        Vector2 dir0, dir1, dir2;
        dir0 = new Vector2(1, 0);
        dir1 = new Vector2(1, 1);
        dir2 = new Vector2(0, 1);

        float prod0, prod1, prod2;
        prod0 = Vector2.Dot(dir0, tiling);
        prod1 = Vector2.Dot(dir1, tiling);
        prod2 = Vector2.Dot(dir2, tiling);

        float sin0, sin1, sin2;
        sin0 = Mathf.Sin(prod0);
        sin1 = Mathf.Sin(prod1);
        sin2 = Mathf.Sin(prod2);

        float tmp = sin0 * scale;
        float o = tmp + sin1 + sin2;
        return o;

    }
   
}
