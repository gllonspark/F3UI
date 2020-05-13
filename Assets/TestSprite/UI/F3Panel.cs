using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3Panel : MonoBehaviour
{
    public List<F3Drawcall> drawCalls = new List<F3Drawcall>();

    public List<F3UIElement> elements = new List<F3UIElement>();

    public F3RectTransform rectTransform;

    public Matrix4x4 worldToLocal
    {
        get
        {
            //float[,] trans = new float[4, 4]
            //{
            //    {1, 0 , 0, transform.position.x},
            //    {0, 1 , 0, transform.position.y},
            //    {0, 0 , 1, transform.position.z},
            //    {0, 0 , 0, 1},
            //};

            //float[,] rotX = new float[4, 4]
            //{
            //    {1, 0 , 0, 1},
            //    {0, Mathf.Cos(-this.transform.eulerAngles.x * Mathf.PI / 180) , -Mathf.Sin(-this.transform.eulerAngles.x * Mathf.PI / 180), 1},
            //    {0, Mathf.Sin(-this.transform.eulerAngles.x * Mathf.PI / 180) , Mathf.Cos(-this.transform.eulerAngles.x * Mathf.PI / 180), 1},
            //    {0, 0 , 0, 1},
            //};

            //float[,] rotY = new float[4, 4]
            //{
            //    {Mathf.Cos(-this.transform.eulerAngles.y * Mathf.PI / 180), 0 , Mathf.Sin(-this.transform.eulerAngles.y * Mathf.PI / 180), 1},
            //    {0, 1 , 0, 1},
            //    {-Mathf.Sin(-this.transform.eulerAngles.y * Mathf.PI / 180), 0 , Mathf.Cos(-this.transform.eulerAngles.y * Mathf.PI / 180), 1},
            //    {0, 0 , 0, 1},
            //};

            //float[,] rotZ = new float[4, 4]
            //{
            //    {Mathf.Cos(-this.transform.eulerAngles.z * Mathf.PI / 180), -Mathf.Sin(-this.transform.eulerAngles.z * Mathf.PI / 180) , 0, 1},
            //    {Mathf.Sin(-this.transform.eulerAngles.z * Mathf.PI / 180), Mathf.Cos(-this.transform.eulerAngles.z * Mathf.PI / 180) , 0, 1},
            //    {0, 0 , 1, 1},
            //    {0, 0 , 0, 1},
            //};

            //float[,] mv = new float[4, 4]
            //{
            //    {1, 0, 0, 0},
            //    {0, 1, 0, 0},
            //    {0, 0, 1, 0},
            //    {0, 0, 0, 1}
            //};

            //mv = HelperMatrix.Matrix4x4(mv, rotZ);
            //mv = HelperMatrix.Matrix4x4(mv, rotX);
            //mv = HelperMatrix.Matrix4x4(mv, rotY);
            //mv = HelperMatrix.Matrix4x4(mv, trans);

            //return HelperMatrix.Convert2Matrix(mv);

            return transform.worldToLocalMatrix;
        }
    }

    public void Awake()
    {
        //worldToLocal = this.transform.worldToLocalMatrix;
    }

    private void Update()
    {
        UpdateDrallCall();
    }

    void UpdateDrallCall()
    {
        //F3Drawcall drawCall = null;

        //drawCall = F3Drawcall.Create(this, elements[0].material, elements[0].texture, elements[0].shader);
        //drawCall.Clear();

        //for (int i = 0; i < elements.Count; i++)
        //{
        //    F3UIElement element = elements[i];
            
        //    element.OnFill();
        //    element.Write2Buffer(drawCall.verts, drawCall.uvs, drawCall.cols);

        //}

        //drawCall.Call();
    }


    public void AddChild(F3UIElement element)
    {
        elements.Add(element);
    }
}
