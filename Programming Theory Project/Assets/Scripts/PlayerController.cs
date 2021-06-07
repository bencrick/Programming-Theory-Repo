using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Shape // INHERITANCE
{
    private float forwardInput;
    private float horizontalInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        Roll(Vector3.up);

        if (Input.GetKeyDown(KeyCode.Space) && contactBelow)
        {
            base.Jump();
        }
    }

    public override void Roll(Vector3 direction) // POLYMORPHISM
    {
        // Player inputs
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Move the player forwards/backwards
        //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * forwardInput);
        Rb.AddTorque(Vector3.right * moveForce * forwardInput);

        // Move the player right/left
        //transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);
        Rb.AddTorque(-Vector3.forward * moveForce * horizontalInput);
    }
}
