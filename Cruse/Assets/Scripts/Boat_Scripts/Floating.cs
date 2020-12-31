using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    private float hight;
    private List<Transform> BouyVerts;
    
    //public GameObject ocean;
    // Start is called before the first frame update
    void Start()
    {
        
      //  rb = GetComponent<Rigidbody>();
      
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float hight = Wave_Manager.WMInstance.GetWaveYCord(transform.position.x,transform.position.z);
        transform.position = new Vector3(transform.position.x, hight, transform.position.z);
    }

    

    
}
