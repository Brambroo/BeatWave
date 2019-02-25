using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlaneGenerator : MonoBehaviour
{
    [Range(0.1f, 20.0f)] //Creates a slider in the inspector
    public float frequency = 5.0f;

    [Range(0.1f, 40.0f)]
    public float detailAmount = 5.0f;

    [Range(0.1f, 30.0f)]
    public float speed = 5.0f;

    public bool wavesEnabled;

    private Mesh plane;
    private Vector3[] verticies;

    public void Start()
    {
       
        wavesEnabled = true;
    }

    public void Update()
    {
        Generate();
    }

    private void Generate()
    {
        plane = this.GetComponent<MeshFilter>().mesh;
        plane.MarkDynamic();
        verticies = plane.vertices;

        int i = 0;
        int j = 0;



        for (int columns = 0; columns < 11; columns++)
        {
            for (int rows = 0; rows < 11; rows++)
            {
                DetermineMovement(i, j);
                i++;
            }
            j++;

        }

        plane.SetVertices(new List<Vector3>(verticies));
        plane.RecalculateBounds();
        plane.RecalculateNormals();
        if (this.gameObject.GetComponent<MeshCollider>() != null)
        {
            Destroy(this.gameObject.GetComponent<MeshCollider>());
            Debug.Log("Deleted MeshCOllider");
        }
        this.gameObject.AddComponent<MeshCollider>();
        MeshCollider collider = this.gameObject.GetComponent<MeshCollider>();
        if (collider != null)
        {
            Debug.Log("ADDED MESHCOLLIDER");
        }
        collider.attachedRigidbody.ResetCenterOfMass();
        collider.sharedMesh = null;
        collider.sharedMesh = plane;
    }

    private void DetermineMovement(int columns, int rows)
    {
        if (wavesEnabled)
        {
            verticies[columns].z = 5 * Mathf.PerlinNoise(Time.time / speed + (verticies[columns].x + this.gameObject.transform.position.x) / detailAmount, //Replace the Mathf.Perlin with data collected from AudioSource
                Time.time / speed + (verticies[columns].y + this.gameObject.transform.position.y) / detailAmount) * frequency;
            verticies[columns].z -= rows;
        }
        else
        {
            verticies[columns].z = 5 * Mathf.PerlinNoise((verticies[columns].x + this.gameObject.transform.position.x) / detailAmount,
                (verticies[columns].y + this.gameObject.transform.position.y) / detailAmount) * frequency;
            verticies[columns].z -= rows;
        }


    }
}
