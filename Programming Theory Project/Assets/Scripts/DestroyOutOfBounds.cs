using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private SceneExtent sceneExtent;

    private float minX, maxX, minY, maxY, minZ, maxZ;
    private float maxOvershootPct = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        sceneExtent = GameObject.Find("Floor").GetComponent<SceneExtent>();

        minX = sceneExtent.minX - (sceneExtent.maxX - sceneExtent.minX) / 100 * maxOvershootPct;
        maxX = sceneExtent.maxX + (sceneExtent.maxX - sceneExtent.minX) / 100 * maxOvershootPct;
        minY = sceneExtent.minY - (sceneExtent.maxY - sceneExtent.minY) / 100 * maxOvershootPct;
        maxY = sceneExtent.maxY + (sceneExtent.maxY - sceneExtent.minY) / 100 * maxOvershootPct;
        minZ = sceneExtent.minZ - (sceneExtent.maxZ - sceneExtent.minZ) / 100 * maxOvershootPct;
        maxZ = sceneExtent.maxZ + (sceneExtent.maxZ - sceneExtent.minZ) / 100 * maxOvershootPct;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < minX)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > maxX) {
            Destroy(gameObject);
        }
        else if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > maxY)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < minZ)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z > maxZ)
        {
            Destroy(gameObject);
        }
    }
}
