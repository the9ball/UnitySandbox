using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    [SerializeField]
    private Material _material;

    private readonly static List<Vector3> vertices
        = new List<Vector3>
        {
            // Front face
            new Vector3(-1.0f,  1.0f, -1.0f), //  0
            new Vector3( 1.0f,  1.0f, -1.0f), //  1
            new Vector3(-1.0f, -1.0f, -1.0f), //  2
            new Vector3( 1.0f, -1.0f, -1.0f), //  3

            // Back face
            new Vector3(-1.0f,  1.0f,  1.0f), //  4
            new Vector3( 1.0f,  1.0f,  1.0f), //  5
            new Vector3(-1.0f, -1.0f,  1.0f), //  6
            new Vector3( 1.0f, -1.0f,  1.0f), //  7

            // Top face
            new Vector3(-1.0f,  1.0f,  1.0f), //  8
            new Vector3( 1.0f,  1.0f,  1.0f), //  9
            new Vector3(-1.0f,  1.0f, -1.0f), // 10
            new Vector3( 1.0f,  1.0f, -1.0f), // 11

            // Bottom face
            new Vector3(-1.0f, -1.0f, -1.0f), // 12
            new Vector3( 1.0f, -1.0f, -1.0f), // 13
            new Vector3(-1.0f, -1.0f,  1.0f), // 14
            new Vector3( 1.0f, -1.0f,  1.0f), // 15

            // Right face
            new Vector3( 1.0f, -1.0f, -1.0f), // 16
            new Vector3( 1.0f,  1.0f, -1.0f), // 17
            new Vector3( 1.0f, -1.0f,  1.0f), // 18
            new Vector3( 1.0f,  1.0f,  1.0f), // 19

            // Left face
            new Vector3(-1.0f, -1.0f,  1.0f), // 20
            new Vector3(-1.0f,  1.0f,  1.0f), // 21
            new Vector3(-1.0f, -1.0f, -1.0f), // 22
            new Vector3(-1.0f,  1.0f, -1.0f), // 23
        };

    private readonly static List<Vector3> normalsA
        = new List<Vector3>
        {
            // Front face
            new Vector3(0, 0, -1),
            new Vector3(0, 0, -1),
            new Vector3(0, 0, -1),
            new Vector3(0, 0, -1),

            // Back face
            new Vector3(0, 0, +1),
            new Vector3(0, 0, +1),
            new Vector3(0, 0, +1),
            new Vector3(0, 0, +1),

            // Top face
            new Vector3(0, +1, 0),
            new Vector3(0, +1, 0),
            new Vector3(0, +1, 0),
            new Vector3(0, +1, 0),

            // Bottom face
            new Vector3(0, -1, 0),
            new Vector3(0, -1, 0),
            new Vector3(0, -1, 0),
            new Vector3(0, -1, 0),
  
            // Right face
            new Vector3(+1, 0, 0),
            new Vector3(+1, 0, 0),
            new Vector3(+1, 0, 0),
            new Vector3(+1, 0, 0),
  
            // Left face
            new Vector3(-1, 0, 0),
            new Vector3(-1, 0, 0),
            new Vector3(-1, 0, 0),
            new Vector3(-1, 0, 0),
        };

    private readonly static List<Vector3> normalsB
        = vertices; // 中心からの向きが法線と等しい

    private readonly static int[] indexes =
    {
        0, 1, 3, 2,
        5, 4, 6, 7,
        8, 9, 11, 10,
        12, 13, 15, 14,
        17, 19, 18, 16,
        21, 23, 22, 20,
    };

    public void Awake()
    {
        Create(new Vector3(-2, 0, 0), normalsA);
        Create(new Vector3(+2, 0, 0), normalsB);
    }

    public void Create(Vector3 position, List<Vector3> normals)
    {
        var child = new GameObject();
        child.transform.parent = transform;
        child.transform.localPosition = position;
        child.transform.localRotation = Quaternion.Euler(45f, 45f, 0f);

        var mesh = new Mesh();
        mesh.SetVertices(vertices);
        mesh.SetNormals(normals);
        mesh.SetIndices(indexes, MeshTopology.Quads, 0);

        var meshFilter = child.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        var meshRenderer = child.AddComponent<MeshRenderer>();
        meshRenderer.material = _material;
    }
}

