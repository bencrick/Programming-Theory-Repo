using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneExtent : MonoBehaviour
{
    public float minX, maxX, minY, maxY, minZ, maxZ;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        minX = rend.bounds.min.x;
        maxX = rend.bounds.max.x;
        minY = rend.bounds.min.y;
        maxY = rend.bounds.max.y;
        minZ = rend.bounds.min.z;
        maxZ = rend.bounds.max.z;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
