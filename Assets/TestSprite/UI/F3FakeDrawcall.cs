using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3FakeDrawcall : MonoBehaviour
{
    public List<Vector3> position = new List<Vector3>();
    public List<Color> color = new List<Color>();
    public List<Vector2> uvs = new List<Vector2>();
    public List<int> triangles = new List<int>();

    private MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    static F3FakeDrawcall instance;
    public static F3FakeDrawcall Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject obj = new GameObject("fakeDrawcall");
                instance = obj.AddComponent<F3FakeDrawcall>();

                instance.meshFilter = obj.GetComponent<MeshFilter>();
                instance.meshRenderer = null;
                if (instance.meshFilter == null)
                {
                    instance.meshFilter = obj.AddComponent<MeshFilter>();
                    instance.meshRenderer = obj.AddComponent<MeshRenderer>();
                }
            }

            return instance;
        }
    }

    private void LateUpdate()
    {
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        //mesh.bounds = new Bounds(new Vector3(0, 0, 0), new Vector3(720, 1080, 0));
        mesh.SetVertices(position);
        
        triangles.AddRange(GenerateCachedIndexBuffer(position.Count, (position.Count >> 1) * 3));
        mesh.triangles = triangles.ToArray();
        
        mesh.SetColors(color);
        mesh.SetUVs(0, uvs);

        position.Clear();
        color.Clear();
        uvs.Clear();
        triangles.Clear();
    }

    //public int[] GenerateCachedIndexBuffer(int vertexCount, int indexCount)
    //{
    //    int[] rv = new int[indexCount];
    //    int index = 0;

    //    for (int i = 0; i < vertexCount; i += 4)
    //    {
    //        rv[index++] = i;
    //        rv[index++] = i + 1;
    //        rv[index++] = i + 2;

    //        rv[index++] = i + 2;
    //        rv[index++] = i + 3;
    //        rv[index++] = i;
    //    }

    //    return rv;
    //}

    public int[] GenerateCachedIndexBuffer(int vertexCount, int indexCount, int startIndex = 0)
    {
        int[] rv = new int[indexCount];
        int index = startIndex;

        for (int i = 0; i < vertexCount; i += 4)
        {
            rv[index++] = i;
            rv[index++] = i + 1;
            rv[index++] = i + 2;

            rv[index++] = i + 2;
            rv[index++] = i + 3;
            rv[index++] = i + 1;
        }

        return rv;
    }
}
