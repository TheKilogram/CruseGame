using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Button_Click : MonoBehaviour
{

    public Button btn;
    private UI_Button_Data data;

    
    // Start is called before the first frame update
    void Start()
    {
        data = btn.GetComponent<UI_Button_Data>();
        btn.onClick.AddListener(handleClick);
        
    }

    public void handleClick()
    {
        
        if(btn.transform.parent.name.Contains("Hull"))
        {
            Instantiate_Object obj = new Instantiate_Object();
            obj.instantiate_Object(Instantiate_Object.ObjType.Hull, data.obj);
        }
        else if (btn.transform.parent.name.Contains("Path"))
        {
            Instantiate_Object obj = new Instantiate_Object();
            obj.instantiate_Object(Instantiate_Object.ObjType.Path,data.obj);
        }
        else if (btn.transform.parent.name.Contains("Deco"))
        {
            Instantiate_Object obj = new Instantiate_Object();
            obj.instantiate_Object(Instantiate_Object.ObjType.Deco,data.obj);
        }
        else if (btn.transform.parent.name.Contains("Wall"))
        {
            Instantiate_Object obj = new Instantiate_Object();
            obj.instantiate_Object(Instantiate_Object.ObjType.Wall,data.obj);
        }



    }
}
