using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleMatrix : MonoBehaviour
{
    public Matrix4x4 matrix;

    public void Update()
    {
        matrix.SetTRS(this.transform.position, this.transform.rotation, this.transform.localScale);

        //Debug.Log("YScale: " + Mathf.Sqrt(matrix.m10 * matrix.m10 + matrix.m11 * matrix.m11 + matrix.m12 * matrix.m12));
        //Debug.Log("lossyScale: " + this.transform.lossyScale);
    }
}
