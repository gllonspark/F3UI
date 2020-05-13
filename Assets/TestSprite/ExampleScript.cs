using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    // Stretch a mesh at an arbitrary angle around the X axis.

    // Angle and amount of stretching.
    public float rotAngle;
    public float stretch;


    MeshFilter mf;
    public Vector3[] origVerts;
    Vector3[] newVerts;

    public Matrix4x4 m;
    public Matrix4x4 inv;

    void Start()
    {
        // Get the Mesh Filter component, save its original vertices
        // and make a new vertex array for processing.
        mf = GetComponent<MeshFilter>();
        origVerts = mf.mesh.vertices;
        newVerts = new Vector3[origVerts.Length];
    }

    public Vector3 ScaleY(Vector3 origin, float stretch)
    {
        origin.y *= stretch;

        return new Vector3(origin.x, origin.y, origin.z);
    }

    void Update()
    {
        // Create a rotation matrix from a Quaternion.
        Quaternion rot = Quaternion.Euler(rotAngle, 0, 0);
        
        m = Matrix4x4.TRS(Vector3.zero, rot, Vector3.one);
        // Get the inverse of the matrix (ie, to undo the rotation).
        inv = m.inverse;

        // For each vertex...
        for (var i = 0; i < origVerts.Length; i++)
        {
            // Rotate the vertex and scale it along its new Y axis.
            var pt = m.MultiplyPoint3x4(origVerts[i]);
            
            Debug.Log(origVerts[i] + " ==> " +  matric_x_vector3(m, origVerts[i]));
            Debug.Log(matric_x_vector3(m, origVerts[i]) + " ==> " + matric_x_vector3(inv, matric_x_vector3(m, origVerts[i])));

            pt.y *= stretch;

            // Return the vertex to its original rotation (but with the
            // scaling still applied).
            newVerts[i] = inv.MultiplyPoint3x4(pt);//pt;// 
        }

        // Copy the transformed vertices back to the mesh.
        mf.mesh.vertices = newVerts;
    }

    Vector3 matric_x_vector3(Matrix4x4 matrix4x4, Vector3 vector3)
    {
        float[,] matrix = new float[4,4]{ 
            { matrix4x4.m00,matrix4x4.m01,matrix4x4.m02,matrix4x4.m03},
            { matrix4x4.m10,matrix4x4.m11,matrix4x4.m12,matrix4x4.m13},
            { matrix4x4.m20,matrix4x4.m21,matrix4x4.m22,matrix4x4.m23},
            { matrix4x4.m30,matrix4x4.m31,matrix4x4.m32,matrix4x4.m33},
        };

        float[] vectorMatrix = new float[4]{vector3.x, vector3.y, vector3.z, 1};

        float[] retMatrix = new float[4] { 1, 1, 1, 1 };

        for(int i = 0; i < 4; i++)
        {
            retMatrix[i] = matrix[i,0] * vectorMatrix[0] + matrix[i,1] * vectorMatrix[1] + matrix[i,2] * vectorMatrix[2] + matrix[i,3] * vectorMatrix[3];
        }

        return new Vector3(retMatrix[0], retMatrix[1], retMatrix[2]);
    }
}