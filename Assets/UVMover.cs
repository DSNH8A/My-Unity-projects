using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVMover : MonoBehaviour
    {
    private Vector3[] vertices = new Vector3[4];
    private Vector2[] uvs = new Vector2[4];
    private int[] triangles = new int[6];

    private Vector2[] headdownUV;

    void Start()
        {
        int vIndex = 0;
        int vIndex0 = vIndex + 0;
        int vIndex1 = vIndex + 1;
        int vIndex2 = vIndex + 2;
        int vIndex3 = vIndex + 3;

        vertices[vIndex0] = new Vector3(0, 0);
        vertices[vIndex1] = new Vector3(0, 1);
        vertices[vIndex2] = new Vector3(1, 1);
        vertices[vIndex3] = new Vector3(1, 0);

        //uvs[0] = new Vector2(0, 1);
        //uvs[1] = new Vector2(1, 1);
        //uvs[2] = new Vector2(0, 0);
        //uvs[3] = new Vector2(1, 0);

        //int x = 0;
        //int y = 100;
        //int hwidth = 100;
        //int hhegth = 100;
        //int texturewidth = 100;
        //int textureheith = 100;

        //uvs[0] = GetUvCoorDinatesFromPixels(x, y + hhegth, texturewidth, textureheith);
        //uvs[1] = GetUvCoorDinatesFromPixels(x + hwidth, y + hhegth, texturewidth, textureheith);
        //uvs[2] = GetUvCoorDinatesFromPixels(x, y, texturewidth, textureheith);
        //uvs[3] = GetUvCoorDinatesFromPixels(x + hwidth, y, texturewidth, textureheith);

        headdownUV = GetUVRectangleFromPixels(0, 100, 100, 100, 100, 100);
        ApplyUvToArray(headdownUV, ref uvs);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 3;

        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        GetComponent<MeshFilter>().mesh = mesh;
        gameObject.transform.localScale = new Vector3(30, 30, 1);
        }

    private Vector2 GetUvCoorDinatesFromPixels(int x, int y, int texturewidth, int textureheigth)
        {
        return new Vector2((float)x / texturewidth, (float)y / textureheigth);
        }

    private Vector2[] GetUVRectangleFromPixels(int x, int y, int width, int heigth, int texturewidth, int textureheigth)
    {
        return new Vector2[]
        {
            GetUvCoorDinatesFromPixels(x, y + heigth, texturewidth, textureheigth),
            GetUvCoorDinatesFromPixels(x + width, y + heigth, texturewidth, textureheigth),
            GetUvCoorDinatesFromPixels(x, y, texturewidth, textureheigth),
            GetUvCoorDinatesFromPixels(x + width, y, texturewidth, textureheigth),
        };
    }

    private void ApplyUvToArray(Vector2[] uv, ref Vector2[] mainUv)
    {
        mainUv[0] = uv[0];
        mainUv[1] = uv[1];
        mainUv[2] = uv[2];
        mainUv[3] = uv[3];
    }
}   
