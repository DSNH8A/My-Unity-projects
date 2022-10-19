using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private Mesh mesh;

    //void Start()
    //{
    //    mesh = new Mesh();
    //    GetComponent<MeshFilter>().mesh = mesh;

    //    float fov = 90f;
    //    int rayCount = 50;
    //    float angle = 0f;
    //    float angleIncrease = fov / rayCount;
    //    float viewDistance = 50f;
    //    Vector3 Origin = Vector3.zero;


    //    Vector3[] vertices = new Vector3[rayCount + 1 + 1];
    //    Vector2[] uv = new Vector2[vertices.Length];
    //    int[] triangles = new int[rayCount * 3];

    //    vertices[0] = Origin;
    //    int vertexindex = 1;
    //    int triangleIndex = 0;

    //    for (int i = 0; i <= rayCount; i++)
    //    {
    //        Vector3 vertex = Origin + GetVector3FromAngle(angle) * viewDistance;
    //        vertices[vertexindex] = vertex;

    //        if (i > 0)
    //        {
    //            triangles[triangleIndex + 0] = 0;
    //            triangles[triangleIndex + 1] = vertexindex - 1;
    //            triangles[triangleIndex + 2] = vertexindex;

    //            triangleIndex += 3;
    //        }

    //        vertexindex++;
    //        angle -= angleIncrease;
    //    }

    //    mesh.vertices = vertices;
    //    mesh.uv = uv;
    //    mesh.triangles = triangles;
    //}

    [SerializeField] private LayerMask layer;
    private float fov = 90f;
    private Vector3 origin = Vector3.zero;
    private float angle = 0f;
    private float startingAngle;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void LateUpdate()
    {
        float angle = startingAngle;
        float length = 50f;
        int rayCount = 50;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        int vIndex = 1;
        int tIndex = 0;
        vertices[0] = origin;

        for (int i = 0; i <= rayCount; i++)
        {
            RaycastHit2D raycasthit = Physics2D.Raycast(origin, GetVector3FromAngle(angle) * length, layer);

            if (raycasthit.collider == null)
            {
                vertices[vIndex] = origin + GetVector3FromAngle(angle) * length;
            }
            else
            {
                vertices[vIndex] = raycasthit.point;  
            }

            if (i > 0)
            {
                triangles[tIndex + 0] = 0;
                triangles[tIndex + 1] = vIndex -1;
                triangles[tIndex + 2] = vIndex;

                tIndex += 3;
            }
            vIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    private Vector3 GetVector3FromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private float GetAngleFromVectorFloat(Vector3 direction)
    {
        direction = direction.normalized;
        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) - fov / 2f;
    }
}
