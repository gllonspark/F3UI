using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class F3Drawcall : MonoBehaviour
{
    public Material mMaterial;
    public Texture mTexture;
    public Shader mShader;

    public List<Vector3> verts = new List<Vector3>();
    public List<Vector2> uvs = new List<Vector2>();
    public List<Vector4> uv2 = new List<Vector4>();
    public List<Color> cols = new List<Color>();

    public Mesh mesh;
    public MeshFilter mFilter;
    public MeshRenderer mRender;
    public int[] indices;

    public F3Panel panel;

    private void Awake()
    {
        mFilter = GetComponent<MeshFilter>();
        mRender = GetComponent<MeshRenderer>();
    }

    public void Clear()
    {
        verts.Clear();
        uvs.Clear();
        uv2.Clear();
        cols.Clear();
    }

    public static F3Drawcall Create(F3Panel panel, Material material, Texture txt, Shader sdr)
    {
        F3Drawcall f3Drawcall = Create();
        
        f3Drawcall.panel = panel;
        f3Drawcall.mMaterial = material;
        f3Drawcall.mTexture = txt;
        f3Drawcall.mShader = sdr;
        return f3Drawcall;
    }

    static F3Drawcall Create()
    {
        GameObject obj = GameObject.Find("drallcall");
        F3Drawcall f3Drawcall = null;
        if (obj == null)
        {
            obj = new GameObject("drallcall");
            DontDestroyOnLoad(obj);
            f3Drawcall = obj.AddComponent<F3Drawcall>();
        }

        return obj.GetComponent<F3Drawcall>();
    }

    internal void Call()
    {
        if(mesh == null)
        {
            mesh = new Mesh();
        }

        mFilter.mesh = mesh;
        mRender.sharedMaterial = mMaterial;

        mesh.Clear();

        mesh.vertices = this.verts.ToArray();

        this.indices = GenerateCachedIndexBuffer(mesh.vertices.Length, (mesh.vertices.Length >> 1) * 3);
        mesh.triangles = this.indices;

        mesh.colors = this.cols.ToArray();
        mesh.uv = this.uvs.ToArray();

        mesh.RecalculateBounds();
    }

    int[] GenerateCachedIndexBuffer(int vertexCount, int indexCount)
    {
        int[] rv = new int[indexCount];
        int index = 0;

        for (int i = 0; i < vertexCount; i += 4)
        {
            rv[index++] = i;
            rv[index++] = i + 1;
            rv[index++] = i + 2;

            rv[index++] = i + 2;
            rv[index++] = i + 3;
            rv[index++] = i;
        }

        return rv;
    }
}
