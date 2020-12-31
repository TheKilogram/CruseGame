using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Lock_XZ : MonoBehaviour
{
    Vector3 rot;
    // Start is called before the first frame update
    void Awake()
    {
        this.rot = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.rot.y = this.transform.eulerAngles.y;
        this.transform.eulerAngles = rot;
    }
}
