using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Bottom_Build : MonoBehaviour
{
    //THIS SCRIP IS OUT DATED/ NO LONGER USED
    private GameObject Canvas_Hull;
    private GameObject Canvas_Path;
    private GameObject Canvas_Deco;
    

    private void Start()
    {
        this.Canvas_Hull = this.transform.GetChild(1).gameObject;
        this.Canvas_Path = this.transform.GetChild(2).gameObject;
        this.Canvas_Deco = this.transform.GetChild(3).gameObject;
    }
    public void ToggleBuildUI()
    {
        bool active = false;
        

        

    }
}
