using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class UI_Fill_Content : MonoBehaviour
{
    private Object[] prefabList;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent.name.Contains("Hull"))
        {
            prefabList = Resources.LoadAll("3DObjects/ShipParts/Hull",typeof(GameObject));
        }
        else if (transform.parent.name.Contains("Path"))
        {
            prefabList = Resources.LoadAll("3DObjects/ShipParts/Path", typeof(GameObject));
        }
        else if (transform.parent.name.Contains("Deco"))
        {
            prefabList = Resources.LoadAll("3DObjects/ShipParts/Deco", typeof(GameObject));
        }
        else if (transform.parent.name.Contains("Wall"))
        {
            prefabList = Resources.LoadAll("3DObjects/ShipParts/Wall", typeof(GameObject));
        }



        foreach (GameObject obj in prefabList)
        {
            GameObject newButton = Instantiate(Resources.Load("UIPrefabs/Button", typeof(GameObject))) as GameObject;
            //print(newButton);
            
            newButton.GetComponent<UI_Button_Data>().obj = obj;
            newButton.GetComponent<UI_Button_Data>().objName = obj.name;

            newButton.GetComponentInChildren<Text>().text = obj.name;

            //Texture2D sp = AssetPreview.GetAssetPreview(obj);
            
            //newButton.GetComponent<Image>().sprite = Sprite.Create(sp,new Rect(0,0,sp.width,sp.height),new Vector2(0.5f,0.5f));
            
            newButton.transform.SetParent(transform);
            
        }

    }

    
}
