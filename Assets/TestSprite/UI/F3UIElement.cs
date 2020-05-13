using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(F3RectTransform))]
public class F3UIElement : MonoBehaviour
{
    public List<Vector3> position;
    public List<Color> color;
    public List<Vector2> uv;
    public List<int> triangles;

    public List<Vector3> relative2PanelVerts;

    public F3RectTransform rectTransform;

    public F3Panel panel;
    Matrix4x4 mLocalToPanel;

    public virtual Material material
    {
        get
        {
            return null;
        }
    }

    public virtual Shader shader
    {
        get
        {
            return null;
        }
    }

    public virtual Texture texture
    {
        get
        {
            return null;
        }
    }

    private void Awake()
    {
        rectTransform = GetComponent<F3RectTransform>();

        position = new List<Vector3>();
        color = new List<Color>();
        uv = new List<Vector2>();
        triangles = new List<int>();

        relative2PanelVerts = new List<Vector3>();
    }

    private void OnEnable()
    {
        panel = this.transform.GetComponentInParent<F3Panel>();
        panel.AddChild(this);
    }


    public void ApplyTransform()
    {
        //relative2PanelVerts.Clear();
        //mLocalToPanel = panel.worldToLocal * this.transform.localToWorldMatrix;
    }

    public void Write2Buffer(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
    {
        //verts.AddRange(position);
        for(int i = 0; i < position.Count; i++)
        {
            verts.Add(this.panel.worldToLocal * position[i]);
        }

        uvs.AddRange(uv);
        cols.AddRange(color);
    }

    public virtual void OnFill()
    {

    }
}
