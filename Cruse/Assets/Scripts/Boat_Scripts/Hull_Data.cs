using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hull_Data : MonoBehaviour
{
    //public Vector3 local_center_pos;
    public Vector3 local_center_mass;
    public float local_length;
    public float local_width;
    public float local_hight;

    private float forwardDist;
    private float backDist;
    private float upDist;
    private float downDist;
    private float leftDist;
    private float rightDist;

    public float density = 1029;
    public float mass;
    public float buildMaterial;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        if(!TryGetComponent(out MeshCollider col))
        {
            col = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        }
        col.convex = true;

        //local_center_pos = GetComponent<Renderer>().bounds.center;
        if(!TryGetComponent(out Rigidbody rb))
        {
            rb = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
        }
        local_center_mass = rb.worldCenterOfMass; //must have a collider 
        Destroy(rb);


        RaycastHit hit;
        if (Physics.Raycast(local_center_mass, Vector3.forward, out hit))
        {
            forwardDist = Vector3.Distance(hit.point, local_center_mass);
            Debug.Log(hit.point);
        }
        if (Physics.Raycast(local_center_mass, Vector3.back, out hit))
        {
            backDist = Vector3.Distance(hit.point, local_center_mass);
            Debug.Log(hit.point);

        }
        if (Physics.Raycast(local_center_mass, Vector3.up, out hit))
        {
            upDist = Vector3.Distance(hit.point, local_center_mass);
            Debug.Log(hit.point);

        }
        if (Physics.Raycast(local_center_mass, Vector3.down, out hit))
        {
            downDist = Vector3.Distance(hit.point, local_center_mass);
            Debug.Log(hit.point);

        }
        if (Physics.Raycast(local_center_mass, Vector3.left, out hit))
        {
            leftDist = Vector3.Distance(hit.point, local_center_mass);
            Debug.Log(hit.point);

        }
        if (Physics.Raycast(local_center_mass, Vector3.right, out hit))
        {
            rightDist = Vector3.Distance(hit.point, local_center_mass);
            Debug.Log(hit.point);

        }
        local_hight = upDist + downDist;
        local_length = forwardDist + backDist;
        local_width = leftDist + rightDist;

        

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(local_center_mass, .3f);
    }
}

