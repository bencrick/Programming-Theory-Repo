using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFallen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
