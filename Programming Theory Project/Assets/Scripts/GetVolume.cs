using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        double volume = VolumeOfMesh(mesh);
        Debug.Log("cur vol: " + volume);
        double desiredVolume = 1.0f;
        double vol_scale = desiredVolume / volume;
        Debug.Log("vol scale: " + vol_scale);
        float dim_scale = (float)Math.Pow(vol_scale, 1.0 / 3.0);
        Debug.Log("dim scale: " + dim_scale);
        transform.localScale = new Vector3(dim_scale, dim_scale, dim_scale);
        //Debug.Log(transform.localScale);
        //Debug.Log(VolumeOfMesh(mesh));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float SignedVolumeOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float v321 = p3.x * p2.y * p1.z;
        float v231 = p2.x * p3.y * p1.z;
        float v312 = p3.x * p1.y * p2.z;
        float v132 = p1.x * p3.y * p2.z;
        float v213 = p2.x * p1.y * p3.z;
        float v123 = p1.x * p2.y * p3.z;
        return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
    }

    float VolumeOfMesh(Mesh mesh)
    {
        float volume = 0;
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;
        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            Vector3 p1 = vertices[triangles[i + 0]];
            Vector3 p2 = vertices[triangles[i + 1]];
            Vector3 p3 = vertices[triangles[i + 2]];
            volume += SignedVolumeOfTriangle(p1, p2, p3);
        }
        return Mathf.Abs(volume);
    }
}
