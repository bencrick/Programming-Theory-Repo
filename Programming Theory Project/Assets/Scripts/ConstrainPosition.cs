using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConstrainPosition : MonoBehaviour
{
    private SceneExtent sceneExtent;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        sceneExtent = GameObject.Find("Floor").GetComponent<SceneExtent>();
        rend = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < sceneExtent.minX)
        {
            transform.position = new Vector3(sceneExtent.minX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > sceneExtent.maxX)
        {
            transform.position = new Vector3(sceneExtent.maxX, transform.position.y, transform.position.z);
        }

        if (transform.position.y < sceneExtent.minY)
        {
            transform.position = new Vector3(transform.position.x, sceneExtent.minY, transform.position.z);
        }
        else if (transform.position.y > Math.Min(sceneExtent.maxX, sceneExtent.maxZ)) //sceneExtent.maxY)
        {
            transform.position = new Vector3(transform.position.x, Math.Min(sceneExtent.maxX, sceneExtent.maxZ), transform.position.z);
        }

        if (transform.position.z < sceneExtent.minZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, sceneExtent.minZ);
        }
        else if (transform.position.z > sceneExtent.maxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, sceneExtent.maxZ);
        }
    }
}
