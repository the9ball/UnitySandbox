using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    [SerializeField]
    private Material _material;

    private readonly static List<Vector3> vertices
        = new List<Vector3>
        {
            new Vector3(-1.0f,  1.0f, -1.0f),
            new Vector3( 1.0f,  1.0f, -1.0f),
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3( 1.0f, -1.0f, -1.0f),
        };

    private readonly static List<Vector3> normals
        = new List<Vector3>
        {
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
        };

    private readonly static List<Vector2> uvs
        = new List<Vector2>
        {
            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(0f, 0f),
            new Vector2(1f, 0f),
        };

    private readonly static int[] indexes =
    {
        0, 1, 3, 2,
    };

    public void Awake()
    {
        Create(new Vector3(0, 0, 0));
    }

    public void Create(Vector3 position)
    {
        var child = new GameObject();
        child.transform.parent = transform;
        child.transform.localPosition = position;

        var mesh = new Mesh();
        mesh.SetVertices(vertices);
        mesh.SetNormals(normals);
        mesh.SetUVs(0, uvs);
        mesh.SetIndices(indexes, MeshTopology.Quads, 0);

        var meshFilter = child.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        var meshRenderer = child.AddComponent<MeshRenderer>();
        meshRenderer.material = _material;
    }
}

