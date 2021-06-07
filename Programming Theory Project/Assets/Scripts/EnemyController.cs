using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRb;
    private Animator enemyAnim;
    private AudioSource enemyAudio;

    private GameObject player;

    public float moveSpeed = 5.0f;
    public float turnSpeed = 10.0f;
    public float jumpForce = 10.0f;

    private float forwardInput;
    private float horizontalInput;

    private bool touchingGround = true;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyAnim = GetComponent<Animator>();

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player = GameObject.Find("Player");

        Invoke("MoveEnemy", 0.0f);

        Invoke("JumpEnemy", 0.0f);

        if (transform.position.y <= 0.5)
        {
            touchingGround = true;
        }
    }

    void MoveEnemy()
    {
        // Target player
        Vector3 targetDirection = (player.transform.position - transform.position).normalized;
        Vector3 axis = Vector3.Cross(Vector3.up, targetDirection).normalized;


        // Move towards the player
        //transform.Translate(targetDirection * Time.deltaTime * moveSpeed);

        // Roll towards the player
        enemyRb.AddTorque(axis * moveSpeed, ForceMode.Force);
    }

    void JumpEnemy()
    {
        if (player.transform.position.y > transform.position.y + 10000 && touchingGround)
        {
            enemyRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
