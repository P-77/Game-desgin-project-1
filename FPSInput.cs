using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private float gravity = -9.8f; // 9.8 m/sec^2 is acceleration due to gravity
    private CharacterController characterController;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
       
       
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        transform.Translate(deltaX * Time.deltaTime,0, deltaZ * Time.deltaTime);
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        //limit diagonal movement to same
        //speed as movement along axis
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime; //scale for framerate independence
                                    //local to global coordinates
        movement = transform.TransformDirection(movement);
        characterController.Move(movement);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime; //scale for framerate independence
    }
}

