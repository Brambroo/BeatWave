using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Wave Generation script: derived from https://www.youtube.com/watch?v=f6cAAjMfPs8&list=
 * 
 * Mainly used for testing at the moment, later the audio analysis will be used to feed the wave movement and will be changed acordingly
 * 
 **/
public class WaveGenerator : MonoBehaviour
{
    [Range (0.1f,20.0f)] //Creates a slider in the inspector
    public float frequency = 5.0f;

    [Range(0.1f, 40.0f)]
    public float detailAmount = 5.0f;

    [Range(0.1f, 30.0f)]
    public float speed = 5.0f;

    public bool wavesEnabled;

    public WaveGenerator[] children;

    private Mesh plane;
    private Vector3[] verticies;

    private Mesh otherPlane;

    public void Start()
    {
        if(this.gameObject.name == "Plane")
        {
            children = new WaveGenerator[] { GameObject.Find("Plane2").GetComponentInChildren<WaveGenerator>(), GameObject.Find("Plane3").GetComponentInChildren<WaveGenerator>(),
            GameObject.Find("Plane4").GetComponentInChildren<WaveGenerator>()};
        }
        else
        {
            children = null;
        }
        wavesEnabled = true;
    }

    /**
     * Updates the values for the children if there are any
     * */
    public void Update()
    {
        Generate();

        if(children != null)
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

    /**
     * Generates the waves
     * */
    private void Generate()
    {
        plane = this.GetComponent<MeshFilter>().mesh;
        plane.MarkDynamic();
        verticies = plane.vertices;

        int i = 0;
        int j = 0;

        //iterate through all of the verticies in the mesh
        for(int columns = 0; columns < 11; columns++) 
        {
            for(int rows = 0; rows < 11; rows++)
            {
                DetermineMovement(i, j);
                i++;
            }
            j++;

        }

        //set the deformed verticies to the mesh
        plane.SetVertices(new List<Vector3>(verticies));
        plane.RecalculateBounds();
        plane.RecalculateNormals();

        //if the gameobject has a mesh collider, delete it so it can be replaced
        if (this.gameObject.GetComponent<MeshCollider>() != null)
        {
            Destroy(this.gameObject.GetComponent<MeshCollider>());
        }

        //add a new mesh collider to the gameobject
        this.gameObject.AddComponent<MeshCollider>();
        MeshCollider collider = this.gameObject.GetComponent<MeshCollider>();
        
        //apply the mesh to the mesh collider
        collider.attachedRigidbody.ResetCenterOfMass();
        collider.sharedMesh = null;
        collider.sharedMesh = plane;
    }

    /**
     * Changes the position of the mesh's verticies
     * Perlin function will be replaced when audio analysis is done
     * */
    private void DetermineMovement(int columns, int rows)
    {
        if (wavesEnabled)
        {
            verticies[columns].z = 5 * Mathf.PerlinNoise(Time.time/speed + (verticies[columns].x + this.gameObject.transform.position.x) / detailAmount, //Replace the Mathf.Perlin with data collected from AudioSource
                Time.time / speed + (verticies[columns].y + this.gameObject.transform.position.y) / detailAmount) * frequency;
            verticies[columns].z -= rows;
        }
        else{
            verticies[columns].z = 5 * Mathf.PerlinNoise((verticies[columns].x + this.gameObject.transform.position.x) / detailAmount,
                (verticies[columns].y + this.gameObject.transform.position.y) / detailAmount) * frequency;
            verticies[columns].z -= rows;
        }
     
    }

}
