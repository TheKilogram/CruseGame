using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Camera_Controller : MonoBehaviour
{
    
    public float Mouse_Move_Boarder_Thickness = 10f; //this val is in pixles. So if mouse is 10 pixles or less for the border of the screen then move the camera.
    

    private Transform Camera;
    private Transform Camera_Parent;
    private Transform Camera_Leveler;

    private Vector3 Local_Rotation;
    private float Cam_Distance = 40f;

    public float Sensitivity_Mouse = 1f;
    public float Sensitivity_Scroll = 3f;
    public float Speed_Orbit = 5f;
    public float Speed_Sroll = 3f;
    public float Speed_Move = .000000003f;
    public bool Camera_Disabled = false;

    // Start is called before the first frame update
    void Start()
    {
        this.Camera = this.transform;
        this.Camera_Parent = this.transform.parent;
        this.Camera_Leveler = this.Camera_Parent.GetChild(1);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //this can change to many things later. this makes it so the camera will not move with mouse input so you can do other things with the mouse.
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Camera_Disabled = !Camera_Disabled;
        }
        if (!Camera_Disabled)
        {
            //input needs to be made better. Should not be hard coded to values.
            if (Input.GetKey(",") || (Input.mousePosition.y >= Screen.height - Mouse_Move_Boarder_Thickness && !Input.GetMouseButton(2)))
            {
                this.Camera_Parent.Translate(0,0,1 * Speed_Move,this.Camera_Leveler);
            }
            if (Input.GetKey("o") || (Input.mousePosition.y <= Mouse_Move_Boarder_Thickness && !Input.GetMouseButton(2)))
            {
                this.Camera_Parent.Translate(0, 0, -1 * Speed_Move, this.Camera_Leveler);
            }
            if (Input.GetKey("a") || (Input.mousePosition.x <= Mouse_Move_Boarder_Thickness && !Input.GetMouseButton(2)))
            {
                this.Camera_Parent.Translate(-1, 0, 0 * Speed_Move, this.Camera_Leveler);
            }
            if (Input.GetKey("e") || (Input.mousePosition.x >= Screen.width - Mouse_Move_Boarder_Thickness && !Input.GetMouseButton(2)))
            {
                this.Camera_Parent.Translate(1, 0, 0 * Speed_Move, this.Camera_Leveler);
            }
            if (Input.GetKey("'"))
            {
                
            }
            if (Input.GetKey("."))
            {
                
            }
            if (Input.GetMouseButton(2))
            {
                if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                {
                    Local_Rotation.x += Input.GetAxis("Mouse X") * Sensitivity_Mouse;
                    Local_Rotation.y -= Input.GetAxis("Mouse Y") * Sensitivity_Mouse;

                    Local_Rotation.y = Mathf.Clamp(Local_Rotation.y, 5f, 90f);
                }

            }
            if(Input.GetAxis("Mouse ScrollWheel") != 0f && !EventSystem.current.IsPointerOverGameObject() ) // IsPointerOverGameObject is miss leading. It returns true if mouse is over UI fales otherwise.
            {
                float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * Sensitivity_Scroll;
                //this is so the scroll zoomes at a defferent rate depending on how far the cam is srolled in or out.
                scrollAmount *= (this.Cam_Distance * .3f);
                this.Cam_Distance += scrollAmount * -1f;
                this.Cam_Distance = Mathf.Clamp(this.Cam_Distance, 2f, 300f);
            }

            Quaternion quart = Quaternion.Euler(Local_Rotation.y, Local_Rotation.x, 0);

            this.Camera_Parent.rotation = Quaternion.Lerp(this.Camera_Parent.rotation, quart, Time.deltaTime * Speed_Orbit);

            if(this.Camera.localPosition.z != this.Cam_Distance * -1f)
            {
                this.Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this.Camera.localPosition.z, this.Cam_Distance * -1f, Time.deltaTime * Speed_Sroll));
            }
        }
        
    }
}
