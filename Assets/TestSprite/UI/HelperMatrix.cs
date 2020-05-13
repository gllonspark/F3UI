using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperMatrix : MonoBehaviour
{
    public static float[,] Matrix4x4(float[,] A, float[,] B)
    {
        float[,] ret = new float[4, 4] 
        {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1}
        };

        for(int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    ret[i, j] += A[i, k] * B[k, j];
                }
            }
        }

        return ret;
    }

    public static float[] Matrix4x3(float[,] A, float[] B)
    {
        for (int i = 0; i < 4; i++)
        {
            B[i] = A[i, 0] * B[0] + A[i, 1] * B[1] + A[i, 2] * B[2] + A[i, 3] * B[3];
        }

        return B;
    }

    public static Matrix4x4 Convert2Matrix(float[,] matrix)
    {
        return new Matrix4x4
        (
            new Vector4(matrix[0, 0], matrix[0, 1], matrix[0, 2], matrix[0, 3]),
            new Vector4(matrix[1, 0], matrix[1, 1], matrix[1, 2], matrix[1, 3]),
            new Vector4(matrix[2, 0], matrix[2, 1], matrix[2, 2], matrix[2, 3]),
            new Vector4(matrix[3, 0], matrix[3, 1], matrix[3, 2], matrix[3, 3])
        );
    }
}
