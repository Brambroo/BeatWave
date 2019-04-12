using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Wave Generation script: derived from https://www.youtube.com/watch?v=f6cAAjMfPs8&list=
 * 
 * Has been altered in several ways. so it fits better within the project.
 * 
 * Used mainly for visual effect for the backgrounds
 * 
 **/
public class MainMenuWaveGenerator3 : MonoBehaviour
{
    [Range(0.1f, 20.0f)] //Creates a slider in the inspector
    public float frequency = 5.0f;

    [Range(0.1f, 40.0f)]
    public float detailAmount = 5.0f;

    [Range(0.1f, 30.0f)]
    public float speed = 5.0f;

    public bool wavesEnabled;

    public MainMenuWaveGenerator3[] children;

    private Mesh plane;
    private Vector3[] verticies;

    private Mesh otherPlane;

    public void Start()
    {
        if (this.gameObject.name == "Plane_2")
        {
            children = new MainMenuWaveGenerator3[] { GameObject.Find("Plane8").GetComponentInChildren<MainMenuWaveGenerator3>(), GameObject.Find("Plane9").GetComponentInChildren<MainMenuWaveGenerator3>(),
            GameObject.Find("Plane10").GetComponentInChildren<MainMenuWaveGenerator3>()};
        }
        else
        {
            children = null;
        }
        wavesEnabled = true;
    }

    public void Update()
    {


        Generate();

        if (children != null)
        {
            for (int i = 0; i < children.Length; i++)
            {
                children[i].frequency = this.frequency;
                children[i].wavesEnabled = this.wavesEnabled;
                children[i].detailAmount = this.detailAmount;
                children[i].speed = this.speed;
            }
        }
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
        }
        this.gameObject.AddComponent<MeshCollider>();
        MeshCollider collider = this.gameObject.GetComponent<MeshCollider>();

        collider.attachedRigidbody.ResetCenterOfMass();
        collider.sharedMesh = null;
        collider.sharedMesh = plane;
    }

    private void DetermineMovement(int columns, int rows)
    {
        //doesn't use audio anaylsis to drive the wave generation
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
