using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Shape // INHERITANCE
{
    private GameObject player;

    // Update is called once per frame
    void FixedUpdate()
    {
        player = GameObject.Find("Player");

        Vector3 targetDirection = (player.transform.position - transform.position).normalized;
        base.Roll(targetDirection);

        if (player.transform.position.y > transform.position.y + 1000 && base.contactBelow)
        {
            base.Jump();
        }
    }
}
