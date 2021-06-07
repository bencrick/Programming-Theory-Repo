using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public float moveSpeed = 10.0f;
    public float turnSpeed = 10.0f;
    public float jumpForce = 10.0f;

    private float forwardInput;
    private float horizontalInput;

    private bool touchingGround = true;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Invoke("MovePlayer", 0.0f);

        Invoke("JumpPlayer", 0.0f);

        if (transform.position.y <= 0.5)
        {
            touchingGround = true;
        }
    }

    void MovePlayer()
    {
        // Player inputs
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Move the player forwards/backwards
        //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * forwardInput);
        playerRb.AddTorque(Vector3.right * moveSpeed * forwardInput);

        // Move the player right/left
        //transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);
        playerRb.AddTorque(-Vector3.forward * moveSpeed * horizontalInput);
    }

    void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && touchingGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            touchingGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.point.y <= transform.position.y)
            {
                touchingGround = true;
                break;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        touchingGround = false;
    }
}
