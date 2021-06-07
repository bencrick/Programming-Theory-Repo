using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public Rigidbody Rb;

    public float moveForce = 10.0f;
    public float jumpForce = 10.0f;

    public bool contactBelow = false;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    public virtual void Roll(Vector3 direction) // ABSTRACTION
    {
        // Target direction
        Vector3 axis = Vector3.Cross(Vector3.up, direction).normalized;

        // Roll towards the direction
        Rb.AddTorque(axis * moveForce, ForceMode.Force);
    }

    public void Jump() // ABSTRACTION
    {
        Rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        contactBelow = false;
    }

    void OnCollisionEnter(Collision collision) // ABSTRACTION
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.point.y <= transform.position.y)
            {
                contactBelow = true;
                break;
            }
        }
    }

    void OnCollisionExit(Collision collision) // ABSTRACTION
    {
        contactBelow = false;
    }
}
