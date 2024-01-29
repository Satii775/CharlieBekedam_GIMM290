using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{

    public float speed = 6.0f;
    public float gravity = -9.8f;
    private CharacterController charController;
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        if (charController.isGrounded) // Check if the character is grounded
        {
            // If grounded, don't apply gravity to the y-component
            movement.y = 0;
        }
        else
        {
            // If not grounded, apply gravity to the y-component
            movement.y += gravity * Time.deltaTime;
        }

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}