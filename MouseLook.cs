using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    [SerializeField]
    private RotationAxes axes = RotationAxes.MouseXAndY;
    
    [SerializeField]
    private float horizontalSensitivity = 3.0f;

    [SerializeField]
    private float verticalSensitivity = 3.0f;
    
    [SerializeField]
    private float minimumVertical = -45.0f;
    
    [SerializeField]
    private float maximumVertical = 45.0f;
    
    private float verticalRotation = 0.0f; //doesn't need Serialized
    
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0,Input.GetAxis("Mouse X") * horizontalSensitivity,
0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            verticalRotation -= Input.GetAxis("Mouse Y") * verticalSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation,
            minimumVertical,
            maximumVertical);
            //keep the same Y angle (i.e., no horizontal rotation)
            float horizontalRotation = transform.localEulerAngles.y;
            transform.localEulerAngles =
            new Vector3(verticalRotation, horizontalRotation, 0);
        }
        else
        {
            // code for both horizontal and
            // vertical rotation goes here
            verticalRotation -= Input.GetAxis("Mouse Y") * verticalSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation,
            minimumVertical,
            maximumVertical);
            // delta is the amount to change the rotation by
            // The Greek letter delta (Δ) is commonly used to represent
            // a discrete amount of change
            float delta = Input.GetAxis("Mouse X") * horizontalSensitivity;
            float horizontalRotation = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(verticalRotation,horizontalRotation,0);
        }
    }
}

