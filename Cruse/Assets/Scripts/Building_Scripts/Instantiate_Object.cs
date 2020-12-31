using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_Object : MonoBehaviour
{
    public enum ObjType
    {
        Hull,
        Wall,
        Path,
        Deco
    }

    public void instantiate_Object(ObjType t, GameObject obj)
    {
        
        switch(t)
        {
            case ObjType.Hull:
                Instantiate(obj);
                break;
            case ObjType.Wall:

                break;
            case ObjType.Path:

                break;
            case ObjType.Deco:

                break;
        }
    }
}
