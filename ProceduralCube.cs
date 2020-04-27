using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralCube : MonoBehaviour
{

    public Texture2D texture;

    void Start()
    {
        var gObj = Create();
    }


    private Vector3[] GetVertices()
    {
        Vector3[] vertices = new Vector3[]
        {
            // Unique vertices for each cube face

            //Front
            new Vector3(0,0,0),
            new Vector3(1,0,0),
            new Vector3(1,1,0),
            new Vector3(0,1,0),

            //Back
            new Vector3(0,0,1),
            new Vector3(1,0,1),
            new Vector3(1,1,1),
            new Vector3(0,1,1),

            //Left
            new Vector3(0,0,0),
            new Vector3(0,0,1),
            new Vector3(0,1,1),
            new Vector3(0,1,0),

            //Right
            new Vector3(1,0,0),
            new Vector3(1,0,1),
            new Vector3(1,1,1),
            new Vector3(1,1,0),

            //Top
            new Vector3(0,1,0),
            new Vector3(0,1,1),
            new Vector3(1,1,1),
            new Vector3(1,1,0),

            //Bottom
            new Vector3(0,0,0),
            new Vector3(0,0,1),
            new Vector3(1,0,1),
            new Vector3(1,0,0)
        };

        return vertices;
    }


    private int[] GetTriangles()
    {
        int[] triangles = new int[]
        {
            //Front (0,1,2,3)
            2, 1, 0,
            3, 2, 0,

            //Back (4,5,6,7)
            4,5,6,
            6,7,4,

            //Left (8,9,10,11)
            8,9,10,
            10,11,8,

            //Right (12,13,14,15)
            14,13,12,
            12,15,14,

            //Top (16,17,18,19)
            16,17,18,
            18,19,16,

            //Bottom (20,21,22,23)
            22,21,20,
            20,23,22

        };

        return triangles;
    }


    private Vector3[] GetNormals()
    {
        Vector3[] normals = new Vector3[]
        {
            //Front
            new Vector3(0,0,-1),
            new Vector3(0,0,-1),
            new Vector3(0,0,-1),
            new Vector3(0,0,-1),

            //Back
            new Vector3(0,0,1),
            new Vector3(0,0,1),
            new Vector3(0,0,1),
            new Vector3(0,0,1),

            //Left
            new Vector3(-1,0,0),
            new Vector3(-1,0,0),
            new Vector3(-1,0,0),
            new Vector3(-1,0,0),

            //Right
            new Vector3(1,0,0),
            new Vector3(1,0,0),
            new Vector3(1,0,0),
            new Vector3(1,0,0),

            //Top
            new Vector3(0,1,0),
            new Vector3(0,1,0),
            new Vector3(0,1,0),
            new Vector3(0,1,0),

            //Bottom
            new Vector3(0,-1,0),
            new Vector3(0,-1,0),
            new Vector3(0,-1,0),
            new Vector3(0,-1,0)
        };

        return normals;
    }


    private List<Vector2> GetUVs()
    {
        List<Vector2> uvs = new List<Vector2>();

        // Front
        uvs.Add(new Vector2(0,0));
        uvs.Add(new Vector2(1,0));
        uvs.Add(new Vector2(1,1));
        uvs.Add(new Vector2(0,1));

        // Back
        uvs.Add(new Vector2(1,0));
        uvs.Add(new Vector2(0,0));
        uvs.Add(new Vector2(0,1));
        uvs.Add(new Vector2(1,1));

        // Left
        uvs.Add(new Vector2(1,0));
        uvs.Add(new Vector2(0,0));
        uvs.Add(new Vector2(0,1));
        uvs.Add(new Vector2(1,1));

        // Right
        uvs.Add(new Vector2(0,0));
        uvs.Add(new Vector2(1,0));
        uvs.Add(new Vector2(1,1));
        uvs.Add(new Vector2(0,1));

        // Top
        uvs.Add(new Vector2(0,1));
        uvs.Add(new Vector2(1,1));
        uvs.Add(new Vector2(1,0));
        uvs.Add(new Vector2(0,0));

        // Bottom
        uvs.Add(new Vector2(0,0));
        uvs.Add(new Vector2(1,0));
        uvs.Add(new Vector2(1,1));
        uvs.Add(new Vector2(0,1));

        return uvs;
    }


    public GameObject Create()
    {

        // Create a new game object
        var gameObject  = new GameObject();
        gameObject.name = "Cube";

        // Add MeshFilter and Renderer
        var filter      = gameObject.AddComponent<MeshFilter>();
        var rend        = gameObject.AddComponent<MeshRenderer>();

        // Init a new mesh
        var mesh        = new Mesh();

        // Set data to the mesh
        mesh.vertices   = GetVertices();
        mesh.triangles  = GetTriangles();
        mesh.normals    = GetNormals();
        mesh.SetUVs       (0, GetUVs());

        mesh.name       = "Cube_mesh";

        // Apply mesh to the mesh filter
        filter.mesh     = mesh;

        // mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        // Create a new material
        var mat = new Material(Shader.Find("Standard"));
        mat.SetTexture("_MainTex", texture);

        // Assign the new material to the MeshRenderer
        rend.material = mat;

        return gameObject;
    }


}