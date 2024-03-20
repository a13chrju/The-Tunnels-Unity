using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour
{
    private Vector3 Rotion_Transform;
    Camera _main;
    public float rotationSpeed = 10f;
    public Rigidbody playerBody;

    // Start is called before the first frame update
    void Start()
    {
        _main = Camera.main;
    }
    void Update()
    {
        Cam_Ctrl_Rotation();
    }
    public void Cam_Ctrl_Rotation()
    {
        // var mouse_x = Input.GetAxis("Mouse X");// Get mouse X axis movement
        var mouse_y = -Input.GetAxis("Mouse Y");// Get mouse Y axis movement
                                                // if (Input.GetKey (KeyCode.Mouse1)) // Right mouse button
                                                //{
                                                //    transform.RotateAround(Rotion_Transform, Vector3.up, mouse_x * 5);
                                                //    transform.RotateAround(Rotion_Transform, transform.right, mouse_y * 5);
                                                //}


        // RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        //  if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        // { 
        //Debug.Log(Vector3.Distance(transform.position, hit.transform.position));
        // transform.RotateAround(playerBody.transform.position, Vector3.up, mouse_x * 5);// rotate up and down

        transform.RotateAround(playerBody.transform.position, transform.right * Time.deltaTime, mouse_y * 5);// rotate left and right
                                                                                                             //    
    }
}
